using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(Dropdown))]
public class DropdownFill : MonoBehaviour
{
    [SerializeField, Multiline]
    private string options;

    private List<string> lines;
    private Dropdown dropdown;

    private int optionsOffset;
    private string query = string.Empty;

    private void Awake()
    {
        lines = options
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

        dropdown = GetComponent<Dropdown>();
        optionsOffset = dropdown.options.Count;
        dropdown.AddOptions(lines);
    }

    private void Update()
    {
        var selected = EventSystem.current?.currentSelectedGameObject?.transform;
        if (!selected || selected == transform || !selected.IsChildOf(transform))
        {
            query = string.Empty;
            return;
        }

        if (!Keyboard.current.anyKey.wasPressedThisFrame)
            return;

        if (query.Length > 0 && Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            query = query.Substring(0, query.Length - 1);
            return;
        }

        for (char i = 'a'; i <= 'z'; i++)
        {
            var key = i.ToString();
            if (((KeyControl)Keyboard.current[key]).wasPressedThisFrame)
            {
                query += key;
                var j = lines.FindIndex(l => l.ToLower().StartsWith(query));
                if (j >= 0)
                {
                    dropdown.value = optionsOffset + j;
                    break;
                }
            }
        }
    }
}
