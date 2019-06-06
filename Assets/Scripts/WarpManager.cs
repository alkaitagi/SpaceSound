using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using Cinemachine;

public class WarpManager : MonoBehaviour
{
    [SerializeField]
    private float duration;
    [SerializeField]
    private NoiseSettings cameraNoise;
    [SerializeField]
    private CanvasToggle canvasToggle;

    public void Warp(Transform destination)
    {
        StopAllCoroutines();
        StartCoroutine(Transition(destination.position));
    }

    private IEnumerator Transition(Vector2 destination)
    {
        var noise = CameraManager.VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        var player = FindObjectOfType<Player>();
        player.enabled = false;

        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(1f);
        canvasToggle.IsVisible = false;

        noise.m_NoiseProfile = cameraNoise;
        player.transform.position = transform.position;
        player.transform.eulerAngles = new Vector3(0, 0, -45);

        yield return new WaitForSeconds(duration);

        canvasToggle.IsVisible = true;
        yield return new WaitForSeconds(1f);
        canvasToggle.IsVisible = false;

        player.enabled = true;
        player.transform.position = destination;

        noise.m_NoiseProfile = null;
        CameraManager.Main.transform.eulerAngles = Vector3.zero;
        //CameraManager.VirtualCamera.transform.position = destination;
    }
}
