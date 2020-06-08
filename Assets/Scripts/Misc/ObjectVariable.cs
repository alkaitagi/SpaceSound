using UnityEngine;

[CreateAssetMenu]
public class ObjectVariable : ScriptableObject
{
    [SerializeField]
    private GameObject value;
    public GameObject Value { get => value; set => this.value = value; }

    public void Default() =>
        Value = default;
}
