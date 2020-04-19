using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    [SerializeField] private float stepsPerSecond = 4;
    [SerializeField] private AudioClip[] footSteps;
    [SerializeField] private AudioSource audioSource;

    private float stepsFrequency => 1.0f / stepsPerSecond;

    private float timer = 0.0f;
    private int footStepsIndex = 0;

    private Rigidbody2D playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if ( playerRigidbody.velocity.magnitude <= 0.2f )
        {
            footStepsIndex = 0;
            timer = stepsFrequency;
            
            return;
        }

        timer += Time.deltaTime;

        if ( timer >= stepsFrequency )
        {
            timer = 0.0f;
            footStepsIndex++;

            if ( footStepsIndex >= footSteps.Length )
            {
                footStepsIndex = 0;
            }

            audioSource.PlayOneShot( footSteps[footStepsIndex] );
        }
    }
}