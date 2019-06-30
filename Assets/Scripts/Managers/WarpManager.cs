using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WarpManager : MonoBehaviour
{
    public static WarpManager Main { get; private set; }

    private static string destination;
    private static string description;

    private bool isLast;
    private bool isWaiting;
    private bool isReversed;
    private bool isFirst;

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
    private GameObject finalQuestion;

    [Space(10)]
    [SerializeField]
    private CanvasToggle finalMessage;
    [SerializeField]
    private CanvasToggle regionInfo;
    [SerializeField]
    private CanvasToggle regionPoll;
    [SerializeField]
    private CanvasToggle initialPoll;

    private void Awake() => Main = this;

    private void Start()
    {
        if (string.IsNullOrEmpty(destination))
        {
            isReversed = true;
            isFirst = true;
            destination = "Sun";
        }
        else
        {
            header.text = destination;
            body.text = description;

            isReversed = destination == "Sun";
            isLast = destination == "Sungazer";
        }

        Player.Main.transform.eulerAngles = new Vector3(0, 0, isReversed ? -225 : -45);
        effects.transform.eulerAngles = new Vector3(0, 0, isReversed ? 180 : 0);

        StartCoroutine(Wait(destination));
    }

    public static void Warp(Gate gate)
    {
        destination = gate?.Destination;
        description = gate?.Description;
        LoadingScreen.Main.StartLoading(() => SceneManager.LoadScene("Warp"));
    }

    public void Continue() => isWaiting = false;

    private IEnumerator Wait(string destination)
    {
        isWaiting = true;
        yield return new WaitForSeconds(duration / 2);

        if (isFirst)
            initialPoll.IsVisible = true;
        else if (isLast)
            finalMessage.IsVisible = true;
        else if (isReversed)
        {
            regionPoll.IsVisible = true;
            if (RegionManager.Completed.Count < 3)
                finalQuestion.SetActive(false);
        }
        else
            regionInfo.IsVisible = true;

        while (isWaiting)
            yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(duration / 2);

        LoadingScreen.Main.StartLoading
        (
            isLast
            ? (UnityAction)(() => Application.Quit())
            : () => SceneManager.LoadScene(destination)
        );
    }
}
