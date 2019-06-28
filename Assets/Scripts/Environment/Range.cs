using UnityEngine;

[System.Serializable]
public struct Range
{
    [SerializeField]
    private float min;
    public float Min => min;
    [SerializeField]
    private float max;
    public float Max => max;
    [SerializeField]
    private bool randomSign;

    public float Length => max - min;
    public float Value { get; private set; }
    public float Lerp
    {
        get => (Value - min) / (max - min);
        set => Value = min + (max - min) * Mathf.Clamp01(value);
    }

    public float Random() => UnityEngine.Random.Range(min, max);
    public void Evaluate()
    {
        Value = Random();
        if (randomSign)
            Value *= UnityEngine.Random.value < .5f ? 1 : -1;
    }
}
