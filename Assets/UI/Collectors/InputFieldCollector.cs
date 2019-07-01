using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

[RequireComponent(typeof(InputField))]
public class InputFieldCollector : BaseCollector
{
    private InputField inputField;

    private void Awake() => inputField = GetComponent<InputField>();

    public override bool Collect(JObject parent)
    {
        if (string.IsNullOrEmpty(inputField.text))
            return false;
        else
        {
            parent[key] = inputField.text;
            return true;
        }
    }
}