using System;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DropdownFill : MonoBehaviour
{
    [SerializeField, Multiline]
    private string options;

    private void Awake() => GetComponent<Dropdown>().AddOptions
    (
        options
        .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .ToList()
    );
}