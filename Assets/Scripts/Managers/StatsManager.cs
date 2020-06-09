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

    private string lastScene = string.Empty;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        Main = this;

        Log = new JObject() { { "id", Guid.NewGuid().ToString() } };
        lastScene = null;
        RegionName = null;
        Deaths.Clear();
        Keys.Clear();

        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        var nextScene = next.name;
        if (lastScene == "Sun" && nextScene == "Warp")
        {
            RegionName = null;
            Deaths.Clear();
            Keys.Clear();
        }
        else if (lastScene != "Sun" && nextScene == "Warp")
        {
            if (!string.IsNullOrEmpty(RegionName))
                Log[RegionName] = new JObject()
                    {
                        {"duration", RegionDuration},
                        {"deathCount", Deaths.Count},
                        {"deaths", new JArray(Deaths)},
                        {"keyCount", Keys.Count},
                        {"keys", new JArray(Keys)}
                    };
        }
        else if (lastScene == "Warp" && nextScene != "Sun")
        {
            RegionDuration = (int)RegionManager.Main.TimeElapsed;
            RegionName = nextScene;
        }
        lastScene = nextScene;
    }

    public void AddPoll(JObject poll)
    {
        if (string.IsNullOrEmpty(RegionName))
            Log["initialPoll"] = poll;
        else
            Log[RegionName]["poll"] = poll;
    }

    public void CountDeath() => Deaths.Add((int)RegionManager.Main.TimeElapsed);

    public void CountKey() => Keys.Add((int)RegionManager.Main.TimeElapsed);
}
