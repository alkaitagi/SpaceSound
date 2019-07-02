using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(Dropdown))]
public class DropdownCollector : BaseCollector
{
    private Dropdown dropdown;

    private void Awake() => dropdown = GetComponent<Dropdown>();

    protected override bool Validate() => dropdown.captionText.text != "Not selected";

    protected override JToken Read() => new JValue(dropdown.captionText.text);
}
