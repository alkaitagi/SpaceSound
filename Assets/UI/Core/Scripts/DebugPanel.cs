using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasToggle))]
public class DebugPanel : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private Text deathText;
    [SerializeField]
    private Text countdownText;

    private CanvasToggle canvasToggle;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        canvasToggle = GetComponent<CanvasToggle>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
            canvasToggle.Toggle();

        deathText.text = StatsManager.Main.Deaths.Count.ToString();
        countdownText.text = (RegionManager.Main ? RegionManager.Main.TimeLeft : 0).ToString();
    }

    public void Skip()
    {
        if (RegionManager.Main)
            RegionManager.Main.End();
    }

    public void Restart() => SceneManager.LoadScene("Main");

    public void Quit() => Application.Quit();
}
