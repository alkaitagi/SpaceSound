using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private void Update()
    {
        var value = RegionManager.Main ? RegionManager.Main.Duration - RegionManager.Main.TimeElapsed : 0;
        text.text = ((int)(value * 100) / 100f).ToString();
    }
}
