using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

public class TogglesCollector : BaseCollector
{
    [SerializeField]
    private Toggle[] toggles;
    [SerializeField]
    private InputField other;

    private void Awake() => toggles = GetComponentsInChildren<Toggle>();

    protected override bool Validate() => toggles.Any(t => t.isOn) || !string.IsNullOrEmpty(other.text);

    protected override JToken Read()
    {
        var options = new JArray(toggles.Where(t => t.isOn).Select(t => t.name));
        if (!string.IsNullOrEmpty(other.text))
            options.Add(other.text);
        return options;
    }
}
