using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomPitch : MonoBehaviour
{
    [SerializeField]
    private Range pitch;

    private void Awake() =>
        GetComponent<AudioSource>().pitch = pitch.Random();
}
