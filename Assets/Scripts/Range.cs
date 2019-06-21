using UnityEngine;

[System.Serializable]
public struct Range
{
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;
    [SerializeField]
    private bool randomSign;

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
