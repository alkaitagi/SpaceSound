using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Asteroid))]
public class AsteroidEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
            foreach (var target in targets)
                ((Asteroid)target).Generate();

        if (GUILayout.Button("Color"))
            foreach (var target in targets)
                ((Asteroid)target).Color();

        if (GUILayout.Button("Clear"))
            foreach (var target in targets)
                ((Asteroid)target).transform.Clear(true);
    }
}
