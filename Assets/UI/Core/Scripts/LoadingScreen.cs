using System.Collections;

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasToggle))]
public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Main { get; private set; }

    private CanvasToggle canvasToggle;

    [SerializeField]
    private float delay;

    private void Awake()
    {
        if (!Main)
        {
            Main = this;
            canvasToggle = GetComponent<CanvasToggle>();
        }
    }

    public void StartLoading(UnityAction action)
    {
        StopAllCoroutines();
        StartCoroutine(Loading(action));
    }

    private IEnumerator Loading(UnityAction action)
    {
        canvasToggle.IsVisible = true;
        yield return new WaitForSecondsRealtime(canvasToggle.Duration + delay);
        action.Invoke();
        canvasToggle.IsVisible = false;
    }
}
