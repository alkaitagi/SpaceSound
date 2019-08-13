using System.Collections;

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasToggle))]
public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Main { get; private set; }

    private CanvasToggle canvasToggle;

    [SerializeField]
    private float timeout;

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
        yield return new WaitForSecondsRealtime(canvasToggle.Duration);

        var timeout = this.timeout;
        while (timeout > 0)
        {
            timeout -= Time.unscaledDeltaTime;
            AudioListener.volume = Mathf.InverseLerp(this.timeout, 0, timeout);
            yield return new WaitForEndOfFrame();
        }

        action.Invoke();
        while (timeout < this.timeout)
        {
            timeout += Time.unscaledDeltaTime;
            AudioListener.volume = Mathf.InverseLerp(0, this.timeout, timeout);
            yield return new WaitForEndOfFrame();
        }

        canvasToggle.IsVisible = false;
    }
}
