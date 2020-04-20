using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/**
 * This is represents the player's torch. When it's health reaches 0 the game is over.
 * Does not necessarily need to be attached to the torch game object itself.
 */
public class Torch : MonoBehaviour
{
    public event Action<float> onTorchHealthUpdated;
    public event Action<List<TorchUpgradeData>> onTorchPerksUpdated;

    [SerializeField] private float health = 100;
    [SerializeField] private float baseDeclineRatePerSecond = 1.0f;


    private float declineRatePerSecond;

    List<TorchUpgradeData> upgradePerks;

    private void Awake()
    {
        upgradePerks = new List<TorchUpgradeData>();
        declineRatePerSecond = baseDeclineRatePerSecond;
        onTorchPerksUpdated += RefreshDataFromPerkChange;
    }

    private void Update()
    {
        float delta = Time.deltaTime * declineRatePerSecond;

        health = Mathf.Max( 0, health - delta );
        onTorchHealthUpdated?.Invoke( health );

        if ( health <= 0 )
        {
            Debug.Log( "torch is dead" );
            enabled = false;

            //Scene will handle restart and pause
            SceneManager.LoadSceneAsync( "GameOverSplash", LoadSceneMode.Additive );
        }
    }

    public void Kindle( float amount )
    {
        health = Mathf.Min( health + amount, 100 );

        Debug.Log( $"torch is kindled by ${amount} for a total of ${health}" );
    }

    public void AddUpgrade(TorchUpgradeData upgradeData)
    {
        upgradePerks.Add(upgradeData);
        onTorchPerksUpdated?.Invoke(upgradePerks);
    }

    void RefreshDataFromPerkChange(List<TorchUpgradeData> upgrades)
    {
        int upgradesCount = upgrades.Count;
        bool isRecentUpgradeDurationChange = upgradesCount > 0 && upgrades[upgradesCount - 1].UpgradeType == TorchUpgradeType.IncreaseDuration;
        if (isRecentUpgradeDurationChange)
        {
            RefreshDeclineRate();
        }
    }

    void RefreshDeclineRate()
    {
        //Get percent of decay o - 100
        float percentageOfDecayTime = 100;
        foreach(TorchUpgradeData data in upgradePerks)
        {
            if(data.UpgradeType == TorchUpgradeType.IncreaseDuration)
            {
                percentageOfDecayTime -= data.Value; 
            }
        }
        percentageOfDecayTime = Mathf.Clamp(percentageOfDecayTime, 0.0f, 100.0f);

        //Normalize to between 0 - 1 and check for 0 error
        float normalizedDecayPercentage = 0;
        if(percentageOfDecayTime > 0.0f)
        {
            normalizedDecayPercentage = percentageOfDecayTime / 100.0f;
        }
        declineRatePerSecond = baseDeclineRatePerSecond * normalizedDecayPercentage;
    }
}