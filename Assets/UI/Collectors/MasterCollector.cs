using System.Linq;

using Newtonsoft.Json.Linq;

using UnityEngine;

public class MasterCollector : MonoBehaviour
{
    [SerializeField]
    private VoidEvent onCollected;

    public void Collect()
    {
        var data = new JObject();
        var collectors = GetComponentsInChildren<BaseCollector>().Where(c => c.gameObject.activeInHierarchy);

        var isValid = true;
        foreach (var collector in collectors)
            isValid &= collector.Collect(data);

        if (isValid)
        {
            StatsManager.Main.AddPoll(data);
            onCollected.Invoke();
        }
    }
}
