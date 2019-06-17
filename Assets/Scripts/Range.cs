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

    public float Random() => UnityEngine.Random.Range(min, max);
    public void Evaluate() => Value = Random();
}
