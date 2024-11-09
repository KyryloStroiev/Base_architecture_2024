using CodeBase.Gameplay.Features.Hero.Factory;
using CodeBase.Gameplay.Levels;
using CodeBase.Infrastructure.State.StateInfrastructure;
using CodeBase.Infrastructure.State.StateMachine;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.State.GameState
{
    internal class BattleEnterState: IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;

        public BattleEnterState(IGameStateMachine gameStateMachine,
            IHeroFactory heroFactory, ILevelDataProvider levelDataProvider)
        {
            _gameStateMachine = gameStateMachine;
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
        }
        
        public void Enter()
        {
            CreateStartEntity();
            
            _gameStateMachine.Enter<BattleLoopState>();
        }

        public void Exit()
        {
            
        }

        private void CreateStartEntity()
        {
            /*_playerFactory.CreateHero(_levelDataProvider.StartPoint);*/
        }
    }
}