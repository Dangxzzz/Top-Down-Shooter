using TDS.Infrastracture.Services;

namespace TDS.Infrastracture.StateMachine
{
    public abstract class AppState : IState
    {
        #region Properties

        protected ServiceLocator ServiceLocator { get; }
        protected StateMachine StateMachine => ServiceLocator.Get<StateMachine>();

        #endregion

        #region Setup/Teardown

        protected AppState(ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        #endregion

        #region IState

        public abstract void Exit();
        public abstract void Enter();

        #endregion
    }
}