using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WarpManager : MonoBehaviour
{
    public static WarpManager Main { get; private set; }

    private static string destination;

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
    private CanvasToggle initialPoll;
    [SerializeField]
    private CanvasToggle regionPoll;

    [Space(10)]
    [SerializeField]
    private CanvasToggle tutorialCanvas;
    [SerializeField]
    private GameObject[] tutorials;

    [Space(10)]
    [SerializeField]
    private GameObject finalQuestion;
    [SerializeField]
    private CanvasToggle finalMessage;
    [SerializeField]
    private GameObject finalEffect;

    [Space(10)]
    [SerializeField]
    private AudioSource themeWarp;
    [SerializeField]
    private AudioSource themeFinal;

    private void Awake() =>
        Main = this;

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
            isReversed = destination == "Sun";
            isLast = destination == "End";
        }

        (isLast ? themeFinal : themeWarp).Play();
        finalEffect.SetActive(isLast);
        
        Player.Main.transform.eulerAngles = new Vector3(0, 0, isReversed ? -225 : -45);
        effects.transform.eulerAngles = new Vector3(0, 0, isReversed ? 180 : 0);

        StartCoroutine(Wait(destination));
    }

    public static void Warp(string destination)
    {
        WarpManager.destination = destination;
        LoadingScreen.Main.StartLoading(() => SceneManager.LoadScene("Warp"));
    }

    public void Continue() => isWaiting = false;

    private IEnumerator Wait(string destination)
    {
        isWaiting = true;
        yield return new WaitForSeconds(duration / 2);

        if (isFirst)
        {
            ShowTutorial(false);
            initialPoll.IsVisible = true;
        }
        else if (isLast)
            finalMessage.IsVisible = true;
        else if (isReversed)
        {
            regionPoll.IsVisible = true;
            if (RegionManager.Completed.Count < 3)
                finalQuestion.SetActive(false);
        }
        else if (!ShowTutorial())
            isWaiting = false;

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

    private bool ShowTutorial(bool showCanvas = true)
    {
        if (tutorials.FirstOrDefault(t => t.name == destination) is GameObject tutorial)
        {
            tutorial.SetActive(true);
            if (showCanvas)
                tutorialCanvas.IsVisible = true;
            return true;
        }
        else
            return false;
    }
}
