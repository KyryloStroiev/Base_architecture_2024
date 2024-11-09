using UnityEngine;

namespace CodeBase.Gameplay.Cameras.Provider
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        void SetMainCamera(Camera camera);
    }
}