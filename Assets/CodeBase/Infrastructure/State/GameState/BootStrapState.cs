using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Service;
using CodeBase.Infrastructure.State.StateInfrastructure;
using CodeBase.Infrastructure.State.StateMachine;
using UnityEngine;

namespace CodeBase.Infrastructure.State.GameState
{
    public class BootStrapState: IState
    {
        private const string BattleScene = "Main";
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootStrapState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService, ILevelDataProvider levelDataProvider)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            Debug.Log("BootStrapState");
            _staticDataService.LoadAll();
            _gameStateMachine.Enter<LoadingBattleState, string>(BattleScene);
        }

        public void Exit()
        {
            
            
        }
    }
}