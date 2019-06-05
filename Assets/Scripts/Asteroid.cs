using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Asteroid))]
public class AsteroidEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        if (GUILayout.Button("Randomize"))
            foreach (var target in targets)
                ((Asteroid)target).Randomize();

        if (GUILayout.Button("Clear"))
            foreach (var target in targets)
                ((Asteroid)target).Clear();
    }
}

public class Asteroid : MonoBehaviour
{
    [System.Serializable]
    private struct Range
    {
        public float min;
        public float max;

        public float Random() => UnityEngine.Random.Range(min, max);
    }

    [SerializeField]
    private Range asteroidScale;
    [SerializeField]
    private Range dotCount;
    [SerializeField]
    private Range dotScale;

    [Space(10)]
    [SerializeField]
    private SpriteRenderer sourceDot;

    public void Randomize()
    {
        Clear();
        transform.localScale = asteroidScale.Random() * Vector3.one;

        float dotCount = this.dotCount.Random();
        for (int i = 0; i < dotCount; i++)
        {
            var dot = Instantiate(sourceDot, transform);
            dot.transform.localPosition = Random.insideUnitCircle / 2.5f;
            dot.transform.localScale *= dotScale.Random();
        }
    }

    public void Clear()
    {
        var dotCount = transform.childCount;
        for (int i = 0; i < dotCount; i++)
        {
            var dot = transform.GetChild(0);
            dot.parent = null;
            DestroyImmediate(dot.gameObject);
        }
    }
}
