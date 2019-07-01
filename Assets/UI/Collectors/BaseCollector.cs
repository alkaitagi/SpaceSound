using UnityEngine;

using Newtonsoft.Json.Linq;

public abstract class BaseCollector : MonoBehaviour
{
    [SerializeField]
    protected string key;

    public abstract bool Collect(JObject parent);
}
