using UnityEngine;

public class RegionManager : MonoBehaviour
{
    [SerializeField]
    private float duration;
    public float Duration => duration;
    [SerializeField]
    private Gate gate;

    public float TimeElapsed { get; private set; }

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

    private void Start() => TimeElapsed = 0;

    private void OnEnable() => Main = this;

    private void OnDisable() => Main = null;

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
