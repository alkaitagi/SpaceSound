using UnityEngine;
using Sungazer.DangerTracker;
using MidiPlayerTK;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Main { get; private set; }

    [SerializeField]
    private MidiFilePlayer midiPlayer;

    [Header("Music")]
    [SerializeField]
    private int transposeScale;
    [SerializeField]
    private float speedScale;

    [Header("Easing")]
    [SerializeField]
    private AnimationCurve easingCurve;
    [SerializeField]
    private float inDuration;
    [SerializeField]
    private float outDuration;

    private float easingTime;

    public int Transpose
    {
        get => midiPlayer.transpose;
        private set => midiPlayer.transpose = value;
    }

    public float Speed
    {
        get => midiPlayer.MPTK_Speed;
        private set => midiPlayer.MPTK_Speed = value;
    }

    private void Start()
    {
        Main = this;
        RegionManager.OnRegionChange.AddListener(RestartMusic);
    }

    private void RestartMusic(bool isRegion)
    {
        if (isRegion)
            midiPlayer.MPTK_RePlay();
        else
            midiPlayer.MPTK_Stop();
    }

    private void Update()
    {
        var isDanger = BaseDangerTracker.Danger > 0;
        var deltaTime = Time.deltaTime / (isDanger ? inDuration : -outDuration);
        easingTime = Mathf.Clamp01(easingTime + deltaTime);
        var easingValue = easingCurve.Evaluate(easingTime);

        Transpose = (int)(transposeScale * easingValue);
        Speed = Mathf.Max(1, speedScale * easingValue);
    }
}
