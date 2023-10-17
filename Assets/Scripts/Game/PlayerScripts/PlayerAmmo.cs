using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDS.Game.PlayerScripts
{
    public class PlayerAmmo : MonoBehaviour
    {
        #region Variables

        [FormerlySerializedAs("_startAmmo")] [SerializeField] private int _initialAmmo;
        [SerializeField] private int _maxAmmo;
        
        #endregion

        #region Events

        public event Action<float> OnChanged;

        #endregion

        #region Properties

        public int Current
        {
            get => _initialAmmo;
            private set
            {
                bool needChange = _initialAmmo != value;

                if (needChange)
                {
                    _initialAmmo = value;
                    OnChanged?.Invoke(_initialAmmo);
                }
            }
        }

        public int MaxHp => _maxAmmo;

        #endregion

        #region Public methods

        public void Change(int value)
        {
            Current = Math.Clamp(_initialAmmo + value, 0, _maxAmmo);
        }

        #endregion
    }
}