using UnityEngine;

namespace CodeBase.Infrastructure.View.ObjectPool
{
    public interface IObjectPool
    {
        void Instantiate();
        GameObject ActiveObject(string pathPrefab, Vector3 position);
        void DisableObject(GameObject obj, string pathPrefab);
    }
}