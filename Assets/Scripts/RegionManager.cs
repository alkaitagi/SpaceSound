using UnityEngine;

public class RegionManager : MonoBehaviour
{
    [SerializeField]
    private float duration;
    [SerializeField]
    private Gate gate;

    public float Timer { get; private set; }

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

    private void Start() => Timer = duration;

    private void OnEnable() => Main = this;

    private void OnDisable() => Main = null;

    private void Update()
    {
        Timer = Mathf.Max(0, Timer - Time.deltaTime);
        if (Timer == 0)
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
