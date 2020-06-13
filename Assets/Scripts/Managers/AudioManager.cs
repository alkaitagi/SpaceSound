using UnityEngine;
using Sungazer.DangerTracker;
using MidiPlayerTK;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private MidiFilePlayer midiPlayer;
    [SerializeField]
    private float transposeScale;

    [Header("Discrete settings")]
    [SerializeField]
    private bool isDiscreteDanger;
    [SerializeField]
    private AnimationCurve outEasingCurve;
    [SerializeField]
    private float outEasingDuration;

    private float outEasingTimer;

    private void Start() =>
        RegionManager.OnRegionChange.AddListener(RestartMusic);

    private void RestartMusic(bool isRegion)
    {
        if (isRegion)
            midiPlayer.MPTK_RePlay();
        else
            midiPlayer.MPTK_Stop();
    }

    private void Update()
    {
        var targetTranspose = GetTranspose();
        if (!isDiscreteDanger)
        {
            midiPlayer.transpose = (int)(transposeScale * targetTranspose);
            return;
        }

        if (targetTranspose > 0)
        {
            midiPlayer.transpose = (int)targetTranspose;
            outEasingTimer = 1;
            return;
        }

        var deltaTime = Time.deltaTime / outEasingDuration;
        outEasingTimer = Mathf.Clamp01(outEasingTimer + deltaTime);
        var easingValue = outEasingCurve.Evaluate(outEasingTimer);
        midiPlayer.transpose = (int)(targetTranspose * easingValue);

        print("D: " + BaseDangerTracker.Danger + " T: " + midiPlayer.transpose);
    }

    private float GetTranspose()
    {
        var transpose = 0f;
        var danger = BaseDangerTracker.Danger;

        if (isDiscreteDanger)
            transpose = danger > 0 ? transposeScale : 0;
        else
            transpose = transposeScale * BaseDangerTracker.Danger;

        return transpose;
    }
}
