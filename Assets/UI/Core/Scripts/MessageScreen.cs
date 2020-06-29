using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasToggle))]
public class MessageScreen : MonoBehaviour
{
    public static MessageScreen Main { get; private set; }

    private CanvasToggle canvasToggle;

    [SerializeField]
    private float timeout;
    [SerializeField]
    private Text text;

    private void Awake()
    {
        if (!Main)
        {
            Main = this;
            canvasToggle = GetComponent<CanvasToggle>();
        }
    }

    public void ShowMessage(string text)
    {
        StopAllCoroutines();
        StartCoroutine(Transition(text));
    }

    private IEnumerator Transition(string text)
    {
        this.text.text = text;
        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(timeout + canvasToggle.Duration);
        canvasToggle.IsVisible = false;
    }
}
