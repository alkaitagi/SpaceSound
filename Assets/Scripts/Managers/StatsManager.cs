using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class StatsManager : ScriptableObject
{
    public static string Log { get; set; } = string.Empty;

    public long TesterID { get; set; }
    public string RegionName { get; set; }
    public int RegionDuration { get; set; }

    public List<int> Deaths { get; set; } = new List<int>();
    public List<int> Keys { get; set; } = new List<int>();

    public static StatsManager Main { get; private set; }

    public void Awake()
    {
        Main = this;
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (next.name == "Warp")
            if (current.name == "Sun")
            {
                Deaths.Clear();
                Keys.Clear();
            }
            else
            {
                RegionDuration = (int)RegionManager.Main.TimeElapsed;
                RegionName = current.name;
            }
    }

    public void CountDeath() => Deaths.Add((int)Time.timeSinceLevelLoad);

    public void CountKey() => Keys.Add((int)Time.timeSinceLevelLoad);
}
