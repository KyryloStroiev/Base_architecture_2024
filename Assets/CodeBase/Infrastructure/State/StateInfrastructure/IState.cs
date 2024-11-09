namespace CodeBase.Infrastructure.State.StateInfrastructure
{
    public interface IState: IExitableState
    {
        void Enter();
    }
}