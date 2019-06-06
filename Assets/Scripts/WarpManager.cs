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
    private NoiseSettings cameraNoise;
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
        var noise = CameraManager.VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        var player = FindObjectOfType<Player>();
        player.enabled = false;

        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(1);
        canvasToggle.IsVisible = false;

        gate.OnWarp.Invoke();

        noise.m_NoiseProfile = cameraNoise;
        player.transform.position = transform.position;
        player.transform.eulerAngles = new Vector3(0, 0, -45);

        yield return new WaitForSeconds(duration);

        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(1);
        canvasToggle.IsVisible = false;

        player.enabled = true;
        player.transform.position = gate.Destination.position;

        noise.m_NoiseProfile = null;
        CameraManager.Main.transform.eulerAngles = Vector3.zero;
        effects.SetActive(false);
    }
}
