using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public AnimationCurve LightIntensityCurve;
    public AnimationCurve OuterRadiusCurve;
    public AnimationCurve InnerRadiusCurve;
    public AnimationCurve FlickerCurve;

    [SerializeField] private Light2D light2DComponent;
    [SerializeField] private float flickerLife = 2.0f; // seconds

    private float lightHealthPercentage = 1.0f;
    private float flickerTimer = 0.0f;

    private void Start()
    {
        Torch torch = FindObjectOfType<Torch>();

        if ( torch )
        {
            torch.onTorchHealthUpdated += UpdateLight;
        }
    }

    private void UpdateLight( float health )
    {
        lightHealthPercentage = health / 100.0f;
    }

    private void Update()
    {
        flickerTimer += Time.deltaTime;

        if ( flickerTimer > flickerLife )
        {
            flickerTimer = 0.0f;
        }

        if ( light2DComponent )
        {
            light2DComponent.pointLightOuterRadius = OuterRadiusCurve.Evaluate( lightHealthPercentage );
            light2DComponent.pointLightInnerRadius = InnerRadiusCurve.Evaluate( lightHealthPercentage );
            light2DComponent.intensity = LightIntensityCurve.Evaluate( lightHealthPercentage ) * FlickerCurve.Evaluate( flickerTimer / flickerLife );
        }
    }
}