using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionPopup;

    [SerializeField] private GameObject lorePopupRoot;
    [SerializeField] private TextMeshProUGUI lorePopupText;

    private static PlayerUi playerUiInstance;

    private static PlayerUi PlayerUiInstance
    {
        get
        {
            if ( playerUiInstance == null )
            {
                playerUiInstance = FindObjectOfType<PlayerUi>();
            }

            return playerUiInstance;
        }
    }

    public static void ShowInteractionPopup( string text )
    {
        PlayerUiInstance.interactionPopup.gameObject.SetActive( true );
        PlayerUiInstance.interactionPopup.text = text;
    }

    public static void HideInteractionPopup()
    {
        PlayerUiInstance.interactionPopup.gameObject.SetActive( false );
    }

    public static void ShowLorePopup( string text )
    {
        PlayerUiInstance.lorePopupRoot.SetActive( true );
        PlayerUiInstance.lorePopupText.text = text;

        PauseHandler.instance.IsPauseInteractionAllowed = false;
        PauseHandler.instance.NotifyPauseUI = false;
        PauseHandler.instance.IsPaused = true;
    }

    public static void HideLorePopup()
    {
        PlayerUiInstance.lorePopupRoot.SetActive( false );
        
        PauseHandler.instance.IsPauseInteractionAllowed = true;
        PauseHandler.instance.NotifyPauseUI = true;
        PauseHandler.instance.IsPaused = false;
    }

    private void Awake()
    {
        HideInteractionPopup();
        HideLorePopup();
    }
}