using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(Dropdown))]
public class DropdownCollector : BaseCollector
{
    private Dropdown dropdown;

    private void Awake() => dropdown = GetComponent<Dropdown>();

    public override JObject Collect() =>
        dropdown.captionText.text == "Not selected"
            ? null
            : new JObject() { { key, dropdown.captionText.text } };
}
