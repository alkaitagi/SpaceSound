using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(InputField))]
public class InputFieldCollector : BaseCollector
{
    private InputField inputField;

    private void Awake() => inputField = GetComponent<InputField>();

    public override JObject Collect() =>
        string.IsNullOrEmpty(inputField.text)
            ? null
            : new JObject() { { key, inputField.text } };
}