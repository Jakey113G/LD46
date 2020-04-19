using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public AnimationCurve LightIntensityCurve;
    public AnimationCurve OuterRadiusCurve;
    public AnimationCurve InnerRadiusCurve;

    [SerializeField]
    private Light2D light2DComponent;

    // Start is called before the first frame update
    void Start()
    {
        Torch torch = FindObjectOfType<Torch>();
        if (torch)
        {
            torch.onTorchHealthUpdated += UpdateLight;
        }
    }

    // Update is called once per frame
    void UpdateLight(float health)
    {
        float healthPercentage = health / 100.0f;
        ApplyLightValues(healthPercentage);
    }

    void ApplyLightValues(float percentage)
    {
        if (light2DComponent)
        {
            light2DComponent.pointLightOuterRadius = OuterRadiusCurve.Evaluate(percentage);
            light2DComponent.pointLightInnerRadius = InnerRadiusCurve.Evaluate(percentage);
            light2DComponent.intensity = LightIntensityCurve.Evaluate(percentage);
        }
    }
}
