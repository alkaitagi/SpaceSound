using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Connect"))
            foreach (var target in targets)
                ((Waypoint)target).Connect();
    }
}
