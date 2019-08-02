using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

public class TogglesCollector : BaseCollector
{
    [SerializeField]
    private Toggle[] toggles;

    [Space(10)]
    [SerializeField]
    private Toggle otherToggle;
    [SerializeField]
    private InputFieldCollector otherCollector;

    private void Awake() => toggles = GetComponentsInChildren<Toggle>();

    protected override bool Validate() =>
        toggles.Any(t => t.isOn)
        || (otherToggle && otherToggle.isOn && otherCollector.IsValid);

    protected override JToken Read()
    {
        var options = new JArray(toggles.Where(t => t.isOn).Select(t => t.name));
        if (otherToggle && otherToggle.isOn)
            options.Add(otherCollector.GetComponent<InputField>().text);
        return options;
    }
}
