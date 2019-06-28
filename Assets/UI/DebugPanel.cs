using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebugPanel : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private CanvasToggle canvasToggle;

    [Space(10)]
    [SerializeField]
    private Text deathText;
    [SerializeField]
    private Text countdownText;

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
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 60;
            onAwake.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
            canvasToggle.Toggle();

        deathText.text = StatsManager.Main.Deaths.Count.ToString();
        countdownText.text = (RegionManager.Main ? RegionManager.Main.TimeLeft : 0).ToString();
    }

    public void SkipRegion()
    {
        if (RegionManager.Main)
            RegionManager.Main.End();
    }

    public void SkipWarp()
    {
        if (WarpManager.Main)
            WarpManager.Main.IsInterrupted = false;
    }

    public void RestartGame() => SceneManager.LoadScene("Main");

    public void QuitGame() => Application.Quit();
}
