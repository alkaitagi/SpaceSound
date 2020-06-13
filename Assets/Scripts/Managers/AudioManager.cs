using UnityEngine;
using Sungazer.DangerTracker;
using MidiPlayerTK;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private MidiFilePlayer player;
    [SerializeField]
    private float transposeScale;
    [SerializeField]
    private bool isDiscrete;

    private void Update()
    {
        var transpose = 0f;
        var danger = BaseDangerTracker.Danger;
        print("Danger: " + danger);
        if (isDiscrete)
            transpose = danger > 0 ? transposeScale : 0;
        else
            transpose = transposeScale * BaseDangerTracker.Danger;

        player.transpose = (int)transpose;
    }
}
