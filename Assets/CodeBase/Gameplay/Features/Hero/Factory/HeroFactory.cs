using CodeBase.Gameplay.Service;
using CodeBase.Infrastructure.View.Factory;
using UnityEngine;

namespace CodeBase.Gameplay.Features.Hero.Factory
{
    public class HeroFactory :  IHeroFactory
    {
        private IStaticDataService _staticDataService;
        private readonly IViewFactory _viewFactory;

        public HeroFactory(IStaticDataService staticDataService, IViewFactory viewFactory)
        {
            _staticDataService = staticDataService;
            _viewFactory = viewFactory;
        }
        
        /*public GameObject CreatePlayer(Vector3 at)
        {
            _staticDataService.GetHeroConfig();

            var playerPrefab = _viewFactory.InstantiateObject(at, playerPrefab);
            
            return playerPrefab;
        }*/

        public GameObject CreateUI()
        {
            return null;
        }
        
       
    }
}