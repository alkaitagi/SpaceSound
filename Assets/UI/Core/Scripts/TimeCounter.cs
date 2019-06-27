using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private void Update() =>
        text.text = (RegionManager.Main ? RegionManager.Main.Timer : 0).ToString();
}
