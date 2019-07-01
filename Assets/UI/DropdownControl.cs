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

    private void Awake()
    {
        var dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(Check);
        Check(dropdown.value);
    }

    private void Check(int value) => onValid.Invoke(valid.Contains(value));
}