using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(ToggleGroup))]
public class ToggleGroupCollector : BaseCollector
{
    private ToggleGroup toggleGroup;

    private void Awake() => toggleGroup = GetComponent<ToggleGroup>();

    public override JObject Collect() =>
        toggleGroup.AnyTogglesOn()
            ? new JObject()
            {{
                key,
                new JArray
                (
                    toggleGroup
                        .ActiveToggles()
                        .Select(t => t.GetComponentInChildren<Text>())
                        .Select(t => t.text)
                )
            }}
            : null;
}
