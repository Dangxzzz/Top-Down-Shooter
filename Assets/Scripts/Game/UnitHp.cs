using System;
using UnityEngine;

namespace TDS.Game
{
    public class UnitHp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _initialHp = 100;
        [SerializeField] private int _maxHp = 100;

        #endregion

        #region Events

        public event Action<float> OnChanged;

        #endregion

        #region Properties

        public float Current
        {
            get => _initialHp;
            private set
            {
                bool needChange = _initialHp != value;

                if (needChange)
                {
                    _initialHp = value;
                    OnChanged?.Invoke(_initialHp);
                }
            }
        }

        public int MaxHp => _maxHp;

        #endregion

        #region Public methods

        public void Change(int value)
        {
            Current = Math.Clamp(_initialHp + value, 0, _maxHp);
        }

        #endregion
    }
}