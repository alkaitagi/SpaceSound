using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(InputField))]
public class InputFieldCollector : BaseCollector
{
    private InputField inputField;

    [Space(10)]
    [SerializeField]
    private int minLength;

    private void Awake() => inputField = GetComponent<InputField>();

    protected override bool Validate() =>
        !string.IsNullOrEmpty(inputField.text)
        && (minLength <= 0 || inputField.text.Length >= minLength);

    protected override JToken Read() => new JValue(inputField.text);
}