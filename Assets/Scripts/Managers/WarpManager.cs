using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarpManager : MonoBehaviour
{
    public static WarpManager Main { get; private set; }
    public static Gate gate;

    private bool isWaiting;
    private bool isReversed;

    [SerializeField]
    private float duration;
    [SerializeField]
    private Transform effects;

    [Space(10)]
    [SerializeField]
    private Text header;
    [SerializeField]
    private Text body;
    [SerializeField]
    private CanvasToggle canvasInfo;
    [SerializeField]
    private CanvasToggle canvasPoll;

    private void Awake() => Main = this;

    private void Start()
    {
        header.text = gate.Destination;
        body.text = gate.Description;

        var player = Player.Main;
        isReversed = gate.Destination == "Sun";

        player.transform.eulerAngles = new Vector3(0, 0, isReversed ? -225 : -45);
        effects.transform.eulerAngles = new Vector3(0, 0, isReversed ? 180 : 0);

        StartCoroutine(Wait());
    }

    public static void Warp(Gate gate)
    {
        WarpManager.gate = gate;
        LoadingScreen.Main.StartLoading(() => SceneManager.LoadScene("Warp"));
    }

    public void Continue() => isWaiting = false;

    private IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(duration / 2);

        (isReversed ? canvasPoll : canvasInfo).IsVisible = true;

        while (isWaiting)
            yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(duration / 2);

        LoadingScreen.Main.StartLoading(() => SceneManager.LoadScene(gate.Destination));
    }
}
