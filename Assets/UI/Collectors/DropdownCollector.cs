using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(Dropdown))]
public class DropdownCollector : BaseCollector
{
    private Dropdown dropdown;

    private void Awake() => dropdown = GetComponent<Dropdown>();

    public override bool Collect(JObject parent)
    {
        if (dropdown.captionText.text == "Not selected")
            return false;
        else
        {
            parent[key] = dropdown.captionText.text;
            return true;
        }
    }
}
