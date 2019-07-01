using System.Linq;

using Newtonsoft.Json.Linq;

using UnityEngine;

public class MasterCollector : MonoBehaviour
{
    [SerializeField]
    private VoidEvent onCollected;

    public void Collect()
    {
        var data = GetComponentsInChildren<BaseCollector>()
            .Where(c => c.gameObject.activeInHierarchy)
            .Select(c => c.Collect());
        //if (data.Any(null))
        //    return null;

        StatsManager.Main.AddPoll(new JObject(data));
        onCollected.Invoke();
    }
}
