using System.Collections;

using UnityEngine;

using Cinemachine;

public class WarpManager : MonoBehaviour
{
    public static WarpManager Main { get; private set; }

    [SerializeField]
    private float duration;
    [SerializeField]
    private GameObject effects;
    [SerializeField]
    private CanvasToggle canvasToggle;

    private void Awake()
    {
        Main = this;
        effects.SetActive(false);
    }

    public void Warp(Gate gate)
    {
        StopAllCoroutines();
        StartCoroutine(Transition(gate));
    }

    private IEnumerator Transition(Gate gate)
    {
        effects.SetActive(true);
        var player = FindObjectOfType<Player>();
        player.enabled = false;

        yield return StartCoroutine(Fade());

        gate.OnWarp.Invoke();
        player.transform.position = transform.position;
        player.transform.eulerAngles = new Vector3(0, 0, -45);

        yield return new WaitForSeconds(duration);

        yield return StartCoroutine(Fade());

        player.enabled = true;
        player.transform.position = gate.Destination.position;
        effects.SetActive(false);
    }

    private IEnumerator Fade()
    {
        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(1);
        canvasToggle.IsVisible = false;
    }
}
