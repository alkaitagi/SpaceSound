using UnityEngine;
using Sungazer.DangerTracker;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private float[] data;

    private AudioSource audioSource;

    private void Awake() =>
        audioSource = GetComponent<AudioSource>();

    private void Update() =>
        print("Danger: " + BaseDangerTracker.Danger);
}
