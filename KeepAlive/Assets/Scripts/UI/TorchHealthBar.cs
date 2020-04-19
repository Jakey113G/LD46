using UnityEngine;
using UnityEngine.UI;

public class TorchHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private Torch torch;

    private void Start()
    {
        torch = FindObjectOfType<Torch>();

        torch.onTorchHealthUpdated += delegate( float health )
        {
            healthSlider.value = health / 100.0f;
        };
    }
}