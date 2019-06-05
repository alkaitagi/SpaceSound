using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AsteroidBelt))]
public class AsteroidBeltEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
            ((AsteroidBelt)target).Generate();

        if (GUILayout.Button("Clear"))
            ((AsteroidBelt)target).transform.Clear(true);
    }
}
