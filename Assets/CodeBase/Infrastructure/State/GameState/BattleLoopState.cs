using CodeBase.Infrastructure.State.StateInfrastructure;
using UnityEngine;

namespace CodeBase.Infrastructure.State.GameState
{
    internal class BattleLoopState: IState, IUpdateable
    {
        public void Enter()
        {
           Debug.Log("BattleLoopState зайшли");
        }

        public void Update()
        {
            Debug.Log("Update Працює");
        }

        public void Exit()
        {
            
        }
    }
}