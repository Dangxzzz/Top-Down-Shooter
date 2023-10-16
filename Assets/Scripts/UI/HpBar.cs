using System;
using TDS.Game;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;
        [SerializeField] private UnitHp _hp;

        public void Start()
        {
            _hp.OnChanged += ChangeBar;
        }

        public void OnDisable()
        {
            _hp.OnChanged -= ChangeBar;
        }

        public void ChangeBar(float currentHp)
        {
            _hpBar.fillAmount = (currentHp/_hp.MaxHp);
        }
    }
}
