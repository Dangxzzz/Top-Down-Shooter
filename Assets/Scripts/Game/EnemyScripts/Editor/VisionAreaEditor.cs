
using TDS.Utillity;
using UnityEditor;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Editor
{
    [CustomEditor(typeof(VisionArea))]
    public class VisonAreaEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            VisionArea fov = (VisionArea)target;
            Handles.color = Color.white;
            
            Vector3 position2D = new Vector3(fov.transform.position.x, fov.transform.position.y, 0f); 
            
            Handles.DrawWireArc(position2D, Vector3.forward, Vector3.up, 360, fov.Radius);

            
            Vector3 viewAngle01 = Quaternion.Euler(0, 0, fov.Angle / 2) * Vector3.down; // Устанавливаем угол вправо
            Vector3 viewAngle02 = Quaternion.Euler(0, 0, -fov.Angle / 2) * Vector3.down;
            
            // Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.z, -fov.Angle / 2); // Меняем eulerY на eulerZ
            // Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.z, fov.Angle / 2); // Меняем eulerY на eulerZ

            Handles.color = Color.yellow;
            Handles.DrawLine(position2D, position2D + viewAngle01 * fov.Radius);
            Handles.DrawLine(position2D, position2D + viewAngle02 * fov.Radius);

            if (fov.IsInView)
            {
                Handles.color = Color.green;
                Handles.DrawLine(fov.transform.position, fov.PlayerRef.transform.position);
            }
        }

        private Vector3 DirectionFromAngle(float eulerZ, float angleInDegrees)
        {
            angleInDegrees += eulerZ; 

            return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f);
        }
    }
}