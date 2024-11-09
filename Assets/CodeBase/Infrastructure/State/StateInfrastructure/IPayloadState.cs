namespace CodeBase.Infrastructure.State.StateInfrastructure
{
    public interface IPayloadState<TPayload> :IExitableState
    {
        void Enter(TPayload payload);
    }
}