using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(ToggleGroup))]
public class ToggleGroupCollector : BaseCollector
{
    private ToggleGroup toggleGroup;

    private void Awake() => toggleGroup = GetComponent<ToggleGroup>();

    public override bool Collect(JObject parent)
    {
        if (toggleGroup.AnyTogglesOn())
        {
            parent[key] = new JArray
            (
                toggleGroup
                    .ActiveToggles()
                    .Where(t => t.isOn)
                    .Select(t => t.GetComponentInChildren<Text>())
                    .Select(t => t.text)
            );
            return true;
        }
        else return false;
    }
}
