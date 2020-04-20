using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public AnimationCurve LightIntensityCurve;
    public AnimationCurve OuterRadiusCurve;
    public AnimationCurve InnerRadiusCurve;
    public AnimationCurve FlickerCurve;
    public AnimationCurve FlickerWeightCurve;

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

            //HACK - The flicker stuff is multiplicative and looks nice and more natural, however it is problematic nearer the start and end of the intensity curve.
            //so we will add weighting against the flicker
            {
                float flickerWeight = FlickerWeightCurve.Evaluate(lightHealthPercentage);
                flickerWeight = Mathf.Clamp01(flickerWeight);

                //Create multiplier and add additional percentage while will be used to weigh more towards intensity
                float flickerMultiplier = FlickerCurve.Evaluate(flickerTimer / flickerLife) * flickerWeight;
                flickerMultiplier += 1.0f - flickerWeight;
                light2DComponent.intensity = LightIntensityCurve.Evaluate(lightHealthPercentage) * flickerMultiplier;
            }
        }
    }
}