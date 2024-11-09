using System;
using System.Collections;

namespace CodeBase.Infrastructure.Loading
{
    public interface ISceneLoader
    {
        void Load(string nameScene, Action onLoader = null);
    }
}