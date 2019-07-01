using System.Linq;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DropdownControl : MonoBehaviour
{
    [SerializeField]
    private int[] valid;
    [SerializeField]
    private BoolEvent onValid;

    private void Awake() => GetComponent<Dropdown>()
        .onValueChanged
        .AddListener
        (
            (int i) =>
            onValid.Invoke(valid.Contains(i))
        );
}