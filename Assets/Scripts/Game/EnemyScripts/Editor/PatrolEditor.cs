using UnityEditor;
using UnityEngine;

namespace TDS.Game.EnemyScripts.Editor
{
    [CustomEditor(typeof(PatrolPath))]
    public class PatrolEditor : UnityEditor.Editor
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
    }
}