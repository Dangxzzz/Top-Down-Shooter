using System;
using UnityEngine;

namespace TDS.Game
{
    public class UnitHp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _initialHp = 3;
        [SerializeField] private int _maxHp = 3;

        #endregion

        #region Events

        public event Action<int> OnChanged;

        #endregion

        #region Properties

        public int Current
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

        #endregion

        #region Public methods

        public void Change(int value)
        {
            Current = Math.Clamp(_initialHp + value, 0, _maxHp);
        }

        #endregion
    }
}