using UnityEngine;

[System.Serializable]
public struct Range
{
    public float min;
    public float max;
    public float value;

    public float Random() => UnityEngine.Random.Range(min, max);
    public void Evaluate() => value = Random();
}

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
    private SpriteRenderer sourceDot;

    private void Awake() => spinRange.Evaluate();

    private void Update() => transform.eulerAngles += spinRange.value * Vector3.forward;

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
    }
}
