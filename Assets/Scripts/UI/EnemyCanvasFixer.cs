using System;
using UnityEngine;

namespace TDS.UI
{
    public class EnemyCanvasFixer : MonoBehaviour
    {
        [SerializeField] private Transform _unitPosition;

        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = transform.localPosition;
        }

        
        void Update()
        {
            transform.up = Vector3.up;

            Quaternion rotation = Quaternion.FromToRotation(_unitPosition.up, Vector3.up);
            transform.localPosition = rotation * _startPosition;
        }
    }
}
