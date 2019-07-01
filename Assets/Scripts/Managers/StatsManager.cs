using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Newtonsoft.Json.Linq;

[CreateAssetMenu]
public class StatsManager : ScriptableObject
{
    public static JObject Log { get; set; }

    public long TesterID { get; set; }
    public string RegionName { get; set; }
    public int RegionDuration { get; set; }

    public List<int> Deaths { get; set; } = new List<int>();
    public List<int> Keys { get; set; } = new List<int>();

    public static StatsManager Main { get; private set; }

    private static string lastScene = string.Empty;

    public void Awake()
    {
        Main = this;
        Log = new JObject() { { "id", Guid.NewGuid().ToString() } };
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        var nextScene = next.name;
        if (nextScene == "Warp" && lastScene == "Sun")
        {
            RegionName = null;
            Deaths.Clear();
            Keys.Clear();
        }
        else if (lastScene == "Warp")
            if (nextScene == "Sun")
                Log[RegionName] = new JObject()
                {
                    {"duration", RegionDuration},
                    {"deathCount", Deaths.Count},
                    {"deaths", new JArray(Deaths)},
                    {"keyCount", Keys.Count},
                    {"keys", new JArray(Keys)}
                };
            else
            {
                RegionDuration = (int)RegionManager.Main.TimeElapsed;
                RegionName = nextScene;
            }
        lastScene = nextScene;
    }

    public void AddPoll(JObject pollData)
    {
        if (RegionName == null)
            Log["initialPoll"] = pollData;
        else
            Log[RegionName] = pollData;
    }

    public void CountDeath() => Deaths.Add((int)RegionManager.Main.TimeElapsed);

    public void CountKey() => Keys.Add((int)RegionManager.Main.TimeElapsed);
}
