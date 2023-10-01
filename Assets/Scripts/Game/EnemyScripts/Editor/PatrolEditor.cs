using UnityEditor;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Editor
{
    [CustomEditor(typeof(PatrolPath))]
    public class PatrolPathEditor : UnityEditor.Editor
    {
        #region Public methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Fill points"))
            {
                ((PatrolPath)target).FillPoints();

                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
        }

        #endregion

        #region Private methods

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmo(PatrolPath path, GizmoType gizmoType)
        {
            if (!IsGameObjectOrAnyChildSelected(path))
            {
                return;
            }
            
            if (path.Points == null || path.Points.Length == 0)
            {
                return;
            }
            
            Gizmos.color = Color.blue;
            Vector3 previousPosition = path.Points[0].position;
            Gizmos.DrawSphere(previousPosition, 0.15f);
            
            for (int i = 1; i < path.Points.Length; i++)
            {
                Vector3 currentPosition = path.Points[i].position;
                Gizmos.DrawSphere(currentPosition, 0.15f);
                Gizmos.DrawLine(previousPosition, currentPosition);
                previousPosition = currentPosition;
            }
            
            Gizmos.DrawLine(previousPosition, path.Points[0].position);
        }
        
        private static bool IsGameObjectOrAnyChildSelected(MonoBehaviour beh)
        {
            GameObject activeGo = Selection.activeGameObject;
            if (activeGo == null)
            {
                return false;
            }
        
            if (beh.gameObject == activeGo)
            {
                return true;
            }
        
            for (int i = 0; i < beh.transform.childCount; i++)
            {
                if (beh.transform.GetChild(i).gameObject == activeGo)
                {
                    return true;
                }
            }
        
            return false;
        }

        #endregion
    }
}
