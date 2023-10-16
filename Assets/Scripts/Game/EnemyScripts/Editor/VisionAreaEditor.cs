
using TDS.Utillity;
using UnityEditor;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Editor
{
    [CustomEditor(typeof(VisionArea))]
    public class VisionAreaEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            VisionArea fov = (VisionArea)target;
            Handles.color = Color.red;
            Handles.zTest = UnityEngine.Rendering.CompareFunction.Less;
            Vector3 position2D = fov.transform.position;

            Quaternion rotation = Quaternion.Euler(0, 0, fov.transform.eulerAngles.z);
            
            Vector3 viewAngle01 = rotation * Quaternion.Euler(0, 0, fov.Angle / 2) * Vector3.down;
            Vector3 viewAngle02 = rotation * Quaternion.Euler(0, 0, -fov.Angle / 2) * Vector3.down;
            
            
            Handles.DrawWireArc(position2D, Vector3.forward, Vector3.down, 360, fov.Radius);
            Handles.DrawWireArc(position2D, Vector3.forward, Vector3.up, 360, fov.MinRadius);
            
            Handles.color = Color.yellow;
            Handles.DrawLine(position2D, position2D + viewAngle01 * fov.Radius);
            Handles.DrawLine(position2D, position2D + viewAngle02 * fov.Radius);

            if (fov.IsInView)
            {
                Handles.color = Color.green;
                Handles.DrawLine(fov.transform.position, fov.PlayerRef.transform.position);
            }
        }
        
    }
}