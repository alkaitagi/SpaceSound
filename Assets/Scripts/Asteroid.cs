using UnityEngine;
using UnityEditor;

[System.Serializable]
public struct Range
{
    public float min;
    public float max;

    public float Random() => UnityEngine.Random.Range(min, max);
}

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

        if (GUILayout.Button("Clear"))
            foreach (var target in targets)
                ((Asteroid)target).transform.Clear(true);
    }
}

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Range asteroidScale;
    [SerializeField]
    private Range dotCount;
    [SerializeField]
    private Range dotScale;

    [Space(10)]
    [SerializeField]
    private SpriteRenderer sourceDot;

    public void Generate()
    {
        transform.Clear();
        transform.localScale = asteroidScale.Random() * Vector3.one;

        float count = dotCount.Random();
        for (int i = 0; i < count; i++)
        {
            var dot = Instantiate(sourceDot, transform);
            dot.transform.localPosition = Random.insideUnitCircle / 2.5f;
            dot.transform.localScale *= dotScale.Random();
        }
    }
}
