using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TorchUpgradeType
{
    IncreaseDuration,
}

[System.Serializable]
public class TorchUpgradeData
{
    public TorchUpgradeType UpgradeType;
    public float Value;
}

public class TorchUpgrade : CollideActivator
{
    [SerializeField]
    public TorchUpgradeData UpgradeData;

    protected override void Interact(GameObject playerGameObject)
    {
        playerGameObject.GetComponent<Torch>().AddUpgrade(UpgradeData);
    }
}
