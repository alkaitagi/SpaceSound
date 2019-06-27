using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int count;
    private bool hooked;

    private void Awake() =>
        RegionManager.OnRegionChange.AddListener(() => SetCount(0));

    private void Update()
    {
        if (!Player.Main)
            hooked = false;
        else if (!hooked)
        {
            Player.Main.GetComponent<Health>().OnDestroy.AddListener(() => SetCount(null));
            hooked = true;
        }
    }

    private void SetCount(int? value)
    {
        count = value ?? count + 1;
        text.text = count.ToString();
    }
}
