using System.Collections;

using UnityEngine;

public class WarpManager : MonoBehaviour
{
    public static WarpManager Main { get; private set; }

    public bool IsInterrupted { get; set; }

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
        IsInterrupted = gate.IsInterrupted;
        StopAllCoroutines();
        StartCoroutine(Transition(gate));
    }

    private IEnumerator Transition(Gate gate)
    {
        effects.SetActive(true);
        var player = Player.Main;
        player.enabled = false;

        yield return StartCoroutine(Fade());
        gate.OnWarpIn.Invoke();

        player.transform.position = transform.position;
        player.transform.eulerAngles = new Vector3(0, 0, gate.IsReversed ? -225 : -45);
        effects.transform.eulerAngles = new Vector3(0, 0, gate.IsReversed ? 180 : 0);

        yield return new WaitForSeconds(duration / 2);

        if (IsInterrupted)
        {
            gate.OnInterrupt.Invoke();
            while (IsInterrupted)
                yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(duration / 2);

        yield return StartCoroutine(Fade());
        gate.OnWarpOut.Invoke();

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
