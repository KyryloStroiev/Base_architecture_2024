using CodeBase.Infrastructure.State.StateInfrastructure;

namespace CodeBase.Infrastructure.State.Factory
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IExitableState;
    }
}