using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(InputField))]
public class InputFieldCollector : BaseCollector
{
    private InputField inputField;

    private void Awake() => inputField = GetComponent<InputField>();

    protected override bool Validate() => !string.IsNullOrEmpty(inputField.text);

    protected override JToken Read() => new JValue(inputField.text);
}