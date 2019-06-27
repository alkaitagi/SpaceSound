using System.Linq;

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
        var gate = FindObjectsOfType(typeof(Gate))
            .Select(g => (Gate)g)
            .FirstOrDefault(g => g.transform.parent.name != "Center");

        if (gate)
            gate.Warp();
    }

    public void Restart() => SceneManager.LoadScene("Main");

    public void Quit() => Application.Quit();
}
