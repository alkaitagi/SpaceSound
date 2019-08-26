using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    [SerializeField]
    private CanvasToggle canvasToggle;

    [Space(10)]
    [SerializeField]
    private Text deathText;
    [SerializeField]
    private Text countdownText;
    [SerializeField]
    private InputField logOutput;

    [Space(10)]
    [SerializeField]
    private VoidEvent onAwake;

    private static bool loaded;

    private void Awake()
    {
        if (loaded)
            Destroy(gameObject);
        else
        {
            loaded = true;
            Application.targetFrameRate = 120;
            onAwake.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.BackQuote))
            canvasToggle.Toggle();

        deathText.text = StatsManager.Main.Deaths.Count.ToString();
        countdownText.text = (RegionManager.Main ? (int)RegionManager.Main.TimeLeft : 0).ToString();
        logOutput.text = StatsManager.Log.ToString();
    }

    public void SkipRegion()
    {
        if (RegionManager.Main)
            RegionManager.Main.End();
    }

    public void SkipWarp()
    {
        if (WarpManager.Main)
            WarpManager.Main.Continue();
    }
}
