using UnityEngine;

namespace CodeBase.Gameplay.Cameras.Provider
{
    public class CameraProvider : ICameraProvider
    {
        public Camera MainCamera { get; private set; }

        public void SetMainCamera(Camera camera)
        {
            MainCamera = camera;
        }
    }
}