using System.Linq;

using UnityEngine.UI;

using Newtonsoft.Json.Linq;

public class TogglesCollector : BaseCollector
{
    private Toggle[] toggles;

    private void Awake() => toggles = GetComponentsInChildren<Toggle>();

    public override JObject Collect() =>
        toggles.Any(t => t.isOn)
            ? new JObject()
            {{
                key,
                new JArray(toggles.Where(t => t.isOn).Select(t => t.name))
            }}
            : null;
}
