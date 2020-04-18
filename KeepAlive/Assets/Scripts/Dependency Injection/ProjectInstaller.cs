using UnityEngine;
using Zenject;

[CreateAssetMenu( fileName = "ProjectInstaller", menuName = "Installers/ProjectInstaller" )]
public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
{
    [SerializeField] private PlayerController playerPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<PlayerController, PlayerController, PlayerControllerFactory>().FromFactory<PrefabFactory<PlayerController>>();
        Container.Bind<PlayerController>().WithId( "playerPrefab" ).FromInstance( playerPrefab );
        Container.Bind<IGameManager>().To<GameManager>().AsSingle().NonLazy();
    }
}