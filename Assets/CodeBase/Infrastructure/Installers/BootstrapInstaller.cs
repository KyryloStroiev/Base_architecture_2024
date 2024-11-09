using CodeBase.Gameplay.Cameras.Provider;
using CodeBase.Gameplay.Common.PhysicsService;
using CodeBase.Gameplay.Common.Time;
using CodeBase.Gameplay.Features.Hero.Factory;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Service;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.State.Factory;
using CodeBase.Infrastructure.State.GameState;
using CodeBase.Infrastructure.State.StateMachine;
using CodeBase.Infrastructure.View.Factory;
using CodeBase.Infrastructure.View.ObjectPool;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindStateFactory();
            BindCommonService();
            BindSceneLoader();
            BindInfrastructureServices();
            BindGameState();
            BindGameStateMachine();
            BindStaticDataService();
            BindFactory();
            BindObjectPool();
            BindAssetManagementServices();
        }

        private void BindSceneLoader() => 
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

        private void BindInputService() => 
            Container.Bind<IInputService>().To<InputService>().AsSingle();

        private void BindAssetManagementServices() => 
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        
        

        private void BindGameStateMachine() => 
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

        private void BindObjectPool() => 
            Container.Bind<IObjectPool>().To<ObjectPool>().AsSingle();

        private void BindFactory()
        {
            Container.Bind<IViewFactory>().To<ViewFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
        }

        private void BindGameState()
        {
            Container.BindInterfacesAndSelfTo<BootStrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
        }
        
        private void BindStateFactory() =>
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

        private void BindStaticDataService() => 
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();

        private void BindCommonService()
        {
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
        }
        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            
        }
        
        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootStrapState>();
        }
    }
}