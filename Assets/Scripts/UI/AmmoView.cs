
using TDS.Game.PlayerScripts;
using TMPro;
using UnityEngine;

namespace TDS.UI
{
    public class AmmoView : MonoBehaviour
    {
        [SerializeField] private PlayerAmmo _playerAmmo;
        [SerializeField] private TextMeshProUGUI _ammoLabel;

        public void Start()
        {
            _playerAmmo.OnChanged += ChangeBar;
        }

        public void OnDisable()
        {
            _playerAmmo.OnChanged -= ChangeBar;
        }

        public void ChangeBar(float currentHp)
        {
            _ammoLabel.text = $"{_playerAmmo.Current}";
        }
    }
}
