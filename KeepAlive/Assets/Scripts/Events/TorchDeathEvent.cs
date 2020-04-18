using UnityEngine;
using UnityEngine.Events;
using Zenject;

[CreateAssetMenu( fileName = "TorchDeathEvent", menuName = "Events/Torch Death Event" )]
public class TorchDeathEvent : ScriptableObject, IInitializable
{
    public UnityEvent onTorchDeath;

    public void Initialize()
    {
        onTorchDeath.RemoveAllListeners();
    }
}