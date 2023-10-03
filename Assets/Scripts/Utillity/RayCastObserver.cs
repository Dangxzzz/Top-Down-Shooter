using UnityEngine;
using System;
using TDS.Game;
using TDS.Utillity;

namespace TDS.Utility
{
    public class RayCastObserver : MonoBehaviour
    {
        [SerializeField] private float fieldOfViewAngle = 90f;
        [SerializeField] private float viewDistance = 100f;
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private UnitHp _target;
        
        
        public event Action<Collider2D> OnEnterRayCast;
        public event Action<Collider2D> OnExitRayCast;
        

        private void Update()
        {
            Vector2 directionToTarget = (_target.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, viewDistance,_playerMask);

            // Проверяем, находится ли цель в пределах угла обзора и в пределах дистанции обзора
            if (Vector2.Angle(-transform.up, directionToTarget) < fieldOfViewAngle * 0.5f)
            {Debug.Log("Pl");
                // Цель находится в поле зрения
                    if (hit.collider!=null)
                    {
                        Debug.Log("Plauyer");
                        OnEnterRayCast?.Invoke(hit.collider);
                    }
            }
            }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
    
            // Угол сектора
            float halfFOV = fieldOfViewAngle * 0.5f;
    
            // Преобразование угла в радианы
            float halfFOVRadians = halfFOV * Mathf.Deg2Rad;
    
            // Центр сектора
            Vector3 center = transform.position;
    
            // Начальный и конечный угол для сектора
            Vector3 startDir = Quaternion.Euler(0, 0, -halfFOV) * -transform.up;
            Vector3 endDir = Quaternion.Euler(0, 0, halfFOV) * -transform.up;
    
            // Начальная и конечная точки сектора
            Vector3 startPoint = center + startDir * viewDistance;
            Vector3 endPoint = center + endDir * viewDistance;

            // Рисование линий для зоны видимости
            Gizmos.DrawLine(center, startPoint);
            Gizmos.DrawLine(center, endPoint);

            // Определение начальной точки линии Raycast (центр объекта _raycastObserver)
            Vector3 raycastStartPoint = transform.position;

            // Определение направления линии Raycast (вверх)
            Vector3 raycastDirection = -transform.up;

            // Рисование линии Raycast с заданной длиной viewDistance
            Gizmos.color = Color.red;
            Gizmos.DrawLine(raycastStartPoint, raycastStartPoint + raycastDirection);
        }
        
    }
}