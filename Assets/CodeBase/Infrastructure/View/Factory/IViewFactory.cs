using UnityEngine;

namespace CodeBase.Infrastructure.View.Factory
{
    public interface IViewFactory
    {
        GameObject InstantiateObject(Vector3 at, string pathPrefab);
        GameObject InstantiateObject(string pathPrefab);
        GameObject InstantiateObject(Vector3 at, GameObject prefab);
    }
}