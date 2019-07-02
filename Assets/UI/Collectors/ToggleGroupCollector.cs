using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(ToggleGroup))]
public class ToggleGroupCollector : BaseCollector
{
    private ToggleGroup toggleGroup;

    private void Awake() => toggleGroup = GetComponent<ToggleGroup>();

    protected override bool Validate() => toggleGroup.AnyTogglesOn();

    protected override JToken Read() => new JArray
    (
        toggleGroup
            .ActiveToggles()
            .Where(t => t.isOn)
            .Select(t => t.GetComponentInChildren<Text>())
            .Select(t => t.text)
    );
}
