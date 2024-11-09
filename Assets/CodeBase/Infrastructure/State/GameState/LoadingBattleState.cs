using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.State.StateInfrastructure;
using CodeBase.Infrastructure.State.StateMachine;
using UnityEngine;

namespace CodeBase.Infrastructure.State.GameState
{
    public class LoadingBattleState: IPayloadState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadingBattleState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string sceneName)
        {
           
            _sceneLoader.Load(sceneName, EnterBattleLoopState);
        }

        private void EnterBattleLoopState()
        {
            _gameStateMachine.Enter<BattleEnterState>();
        }

        public void Exit()
        {
           
        }
    }
}