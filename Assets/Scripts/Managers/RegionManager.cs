using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    [SerializeField]
    private float duration;
    public float Duration => duration;
    [SerializeField]
    private Gate gate;

    public float TimeElapsed { get; private set; }
    public float TimeLeft => Duration - TimeElapsed;

    public static VoidEvent OnRegionChange { get; private set; } = new VoidEvent();

    private static RegionManager main;
    public static RegionManager Main
    {
        get => main;
        private set
        {
            main = value;
            OnRegionChange.Invoke();
        }
    }

    public static List<string> Completed { get; private set; } = new List<string>();

    private void Awake() => Main = this;

    private void Start()
    {
        TimeElapsed = 0;
        Completed.Add(StatsManager.Main.RegionName);
    }

    private void Update()
    {
        TimeElapsed = Mathf.Clamp(TimeElapsed + Time.deltaTime, 0, Duration);
        if (TimeElapsed == Duration)
        {
            enabled = false;
            End();
        }
    }

    public void End()
    {
        if (!gate.IsLocked)
        {
            gate.Open();
            if (Player.Main)
                Player.Main.GetComponent<Health>().Destroy();
        }
    }
}
