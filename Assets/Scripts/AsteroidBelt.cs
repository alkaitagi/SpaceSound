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

public class AsteroidBelt : MonoBehaviour
{
    [SerializeField]
    private Range radiusRange;
    [SerializeField]
    private int count;
    [SerializeField]
    private Asteroid sourceAsteroid;

    public void Generate()
    {
        transform.Clear(true);

        for (int i = 0; i < count; i++)
        {
            var instance = Instantiate(sourceAsteroid, transform);
            instance.Generate();
            instance.transform.localPosition = radiusRange.Random() * Random.insideUnitCircle.normalized;
        }
    }
}
