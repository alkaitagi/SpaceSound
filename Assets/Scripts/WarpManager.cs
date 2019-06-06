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

    public void Warp(Transform destination)
    {
        StopAllCoroutines();
        StartCoroutine(Transition(destination.position));
    }

    private IEnumerator Transition(Vector2 destination)
    {
        effects.SetActive(true);
        var noise = CameraManager.VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        var player = FindObjectOfType<Player>();
        player.enabled = false;

        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(1);
        canvasToggle.IsVisible = false;

        noise.m_NoiseProfile = cameraNoise;
        player.transform.position = transform.position;
        player.transform.eulerAngles = new Vector3(0, 0, -45);

        yield return new WaitForSeconds(duration);

        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(1);
        canvasToggle.IsVisible = false;

        player.enabled = true;
        player.transform.position = destination;

        noise.m_NoiseProfile = null;
        CameraManager.Main.transform.eulerAngles = Vector3.zero;
        effects.SetActive(false);
    }
}
