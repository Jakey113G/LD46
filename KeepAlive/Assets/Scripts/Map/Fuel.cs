using UnityEngine;

public class Fuel : CollideActivator
{
    [SerializeField] private float amount = 20.0f;

    protected override void Interact( GameObject playerGameObject )
    {
        playerGameObject.GetComponent<Torch>().Kindle( amount );
    }
}