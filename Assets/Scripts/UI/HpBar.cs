using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;

        public void ChangeBar(float currentHp)
        {
            _hpBar.fillAmount = currentHp/100;
        }
    }
}
