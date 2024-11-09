using UnityEngine;

namespace CodeBase.Gameplay.Features.Hero.Factory
{
    public interface IHeroFactory
    {
        GameObject CreateUI();
        /*GameObject CreateHero(Vector3 startPoint);*/
    }
}