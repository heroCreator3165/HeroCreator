using UnityEditor;
using UnityEngine;

namespace Legacy
{
    [CustomEditor(typeof(ProjectfileParser))]
    public class ProjectfileParserEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Load"))
            {
                (target as ProjectfileParser).LoadAll();
            }
            if (GUILayout.Button("Store"))
            {
                (target as ProjectfileParser).StoreAll(false);
            }
        }
    }
}