using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

public abstract class BaseCollector : MonoBehaviour
{
    [SerializeField]
    private string key;
    [SerializeField]
    private Graphic indicator;

    public bool Collect(JObject parent)
    {
        var isValid = IsValid;

        if (indicator)
            indicator.color = isValid ? Color.white : Color.red;
        if (isValid)
            parent[key] = Read();

        return isValid;
    }

    public bool IsValid => Validate();

    protected abstract bool Validate();
    protected abstract JToken Read();
}
