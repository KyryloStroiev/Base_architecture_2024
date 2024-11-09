using System.Collections.Generic;
using CodeBase.Infrastructure.View.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.View.ObjectPool
{
    public class ObjectPool : IObjectPool
    {
        private Dictionary<string, Queue<GameObject>> _objectQueue = new();

        private int _sizePool = 20;
        private IViewFactory _viewFactory;

        public ObjectPool(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public void Instantiate()
        {
            
        }

        public GameObject ActiveObject(string pathPrefab, Vector3 position)
        {
            if (_objectQueue.ContainsKey(pathPrefab))
            {
                GameObject obj = null;
                if (_objectQueue[pathPrefab].Count > 0)
                {
                    obj = _objectQueue[pathPrefab].Dequeue();
                }
                else
                {
                    obj = _viewFactory.InstantiateObject(pathPrefab);
                    _sizePool++;
                }

                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }

            return null;
        }

        public void DisableObject(GameObject obj, string pathPrefab)
        {
            obj.SetActive(false);
            _objectQueue[pathPrefab].Enqueue(obj);
        }

        private void CreateObject(string pathPrefab)
        {
            _objectQueue[pathPrefab] = new Queue<GameObject>();

            for (int i = 0; i < _sizePool; i++)
            {
                GameObject obj = _viewFactory.InstantiateObject(pathPrefab);
                _objectQueue[pathPrefab].Enqueue(obj);
                obj.SetActive(false);
            }
        }
    }
}