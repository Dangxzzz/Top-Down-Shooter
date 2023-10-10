using TDS.Infrastracture.Services;
using TDS.Infrastracture.StateMachine;
using UnityEngine;

namespace TDS.Infrastracture
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            StateMachine.StateMachine sm = new();
            ServiceLocator.Instance.Register(sm);
            sm.Enter<BootstrapState>();
        }

        #endregion
    }
}