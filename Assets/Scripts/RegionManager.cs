using UnityEngine;

[RequireComponent(typeof(Gate))]
public class RegionManager : MonoBehaviour
{
    [SerializeField]
    private float safeTime;
    [SerializeField]
    private float dangerTime;

    public Gate Gate { get; set; }
    public static RegionManager Main { get; private set; }

    private void Awake() => Gate = GetComponent<Gate>();

    private void Start() => Invoke("End", safeTime + dangerTime);

    private void OnEnable() => Main = this;

    private void OnDisable() => Main = null;

    private void End()
    {
        if (!Gate.IsLocked)
        {
            Gate.Open();
            if (Player.Main)
                Player.Main.GetComponent<Health>().Destroy();
        }
    }
}
