namespace TDS.Infrastracture.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}