using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Device
{
    PC,
    Gamepad,
    None,
}

[System.Serializable]
public class InputInfo
{
    public Sprite Image;
    public string Description;
}

public class IntroInputInfo : MonoBehaviour
{
    [SerializeField]
    public InputInfo ControllerInfo;
    [SerializeField]
    public InputInfo KeyboardInfo;

    [SerializeField]
    private GameObject objectForDeviceImage;

    private Device lastUpdatedDevice;



    // Start is called before the first frame update
    void Start()
    {
        lastUpdatedDevice = Device.None;
    }

    // Update is called once per frame
    void Update()
    {
        //Bad way to check for device, as it doesn't check for last input just the existence of controller (string in first item of joysticks)
        string[] devices = Input.GetJoystickNames();
        bool isGamePad = devices.Length > 0 && devices[0].Length > 0;

        Device newDevice = isGamePad ? Device.Gamepad : Device.PC;
        if (newDevice != lastUpdatedDevice)
        {
            switch (newDevice)
            {
                case Device.Gamepad:
                { 
                    UpdateUIIntroForGamePad();
                    break;
                }
                case Device.PC:
                {
                    UpdateUIIntroForPC();
                    break;
                }
                default:
                {
                    Debug.LogAssertion("No device set for intro UI");
                    break;
                }
            }

            lastUpdatedDevice = newDevice;
        }
    }

    void UpdateUIIntroForGamePad()
    {
        UpdateImageToDevice(ControllerInfo.Image);
        UpdateTextToDevice(ControllerInfo.Description);
    }

    void UpdateUIIntroForPC()
    {
        UpdateImageToDevice(KeyboardInfo.Image);
        UpdateTextToDevice(KeyboardInfo.Description);
    }

    void UpdateImageToDevice(Sprite sprite)
    {
        Image image = objectForDeviceImage.GetComponent<Image>();
        if (image != null)
        {
            image.sprite = sprite;
        }
    }

    void UpdateTextToDevice(string textDescription)
    {
        TextMeshProUGUI[] textComps = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textComp in textComps)
        {
            textDescription = textDescription.Replace("\\n", "\n"); //Hack for serialised fields escaping escaped characters
            textComp.text = textDescription;
        }
    }
}
