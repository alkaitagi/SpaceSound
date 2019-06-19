using System;

using UnityEngine;

[Serializable]
public struct Range
{
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

    public float Value { get; private set; }
    public float Lerp 
    {
        get => (Value - min) / (max - min);
        set => Value = min + (max - min) * Mathf.Clamp01(value);
    }

    public float Random() => UnityEngine.Random.Range(min, max);
    public void Evaluate() => Value = Random();
}
