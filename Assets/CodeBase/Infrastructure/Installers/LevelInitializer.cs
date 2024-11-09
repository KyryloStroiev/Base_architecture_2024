using CodeBase.Gameplay.Cameras.Provider;
using CodeBase.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform StartHeroPoint;
        public Camera MainCamera;
        private ILevelDataProvider _levelDataProvider;
        private ICameraProvider _cameraProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider, ICameraProvider cameraProvider)
        {
            _levelDataProvider = levelDataProvider;
            _cameraProvider = cameraProvider;
        }
        
        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(StartHeroPoint.position);
            _cameraProvider.SetMainCamera(MainCamera);
        }
    }
}