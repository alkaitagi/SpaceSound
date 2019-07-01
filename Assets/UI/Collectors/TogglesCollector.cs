using System.Linq;

using UnityEngine.UI;

using Newtonsoft.Json.Linq;

public class TogglesCollector : BaseCollector
{
    private Toggle[] toggles;

    private void Awake() => toggles = GetComponentsInChildren<Toggle>();

    public override bool Collect(JObject parent)
    {
        if (toggles.Any(t => t.isOn))
        {
            parent[key] = new JArray(toggles.Where(t => t.isOn).Select(t => t.name));
            return true;
        }
        else return false;
    }
}
