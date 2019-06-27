using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasToggle))]
public class DebugPanel : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;

    private CanvasToggle canvasToggle;

    private void Awake()
    {
        canvasToggle = GetComponent<CanvasToggle>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
            canvasToggle.Toggle();
    }

    public void Skip()
    {
        if (RegionManager.Main)
            RegionManager.Main.End();
    }

    public void Restart() => SceneManager.LoadScene("Main");

    public void Quit() => Application.Quit();
}
