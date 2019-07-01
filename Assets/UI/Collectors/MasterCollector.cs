using System.Linq;

using Newtonsoft.Json.Linq;

using UnityEngine;

public class MasterCollector : MonoBehaviour
{
    [SerializeField]
    private VoidEvent onCollected;

    public void Collect()
    {
        var parent = new JObject();
        if
        (
            GetComponentsInChildren<BaseCollector>()
            .Where(c => c.gameObject.activeInHierarchy)
            .Select(c => c.Collect(parent))
            .All(b => b)
        )
        {
            StatsManager.Main.AddPoll(parent);
            onCollected.Invoke();
        }
        else
        {
            StatsManager.Main.AddPoll(parent);
            onCollected.Invoke();
        }
    }
}
