using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Range asteroidScale;
    [SerializeField]
    private Range dotCount;
    [SerializeField]
    private Range dotScale;
    [SerializeField]
    private Range spinRange;

    [Space(10)]
    [SerializeField]
    private Gradient bodyColor;
    [SerializeField]
    private Gradient dotColor;

    [Space(10)]
    [SerializeField]
    private SpriteRenderer sourceDot;

    private void Awake() => spinRange.Evaluate();

    private void Update() => transform.eulerAngles += spinRange.Value * Vector3.forward;

    public void Generate()
    {
        transform.Clear(true);
        transform.localScale = asteroidScale.Random() * Vector3.one;

        float count = dotCount.Random();
        for (int i = 0; i < count; i++)
        {
            var dot = Instantiate(sourceDot, transform);
            dot.transform.localPosition = Random.insideUnitCircle / 2.5f;
            dot.transform.localScale *= dotScale.Random();
        }

        Color();
    }

    public void Color()
    {
        GetComponent<SpriteRenderer>().color = bodyColor.Evaluate(Random.Range(0, 1f));
        foreach (Transform dot in transform)
            dot.GetComponent<SpriteRenderer>().color = dotColor.Evaluate(Random.Range(0, 1f));
    }
}

#if UNITY_EDITOR

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

#endif
