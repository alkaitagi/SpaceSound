using System.Linq;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private float[] data;

    private AudioSource source;

    private void Awake() => source = GetComponent<AudioSource>();

    private void Update() => source.clip.SetData(data, 0);
}
