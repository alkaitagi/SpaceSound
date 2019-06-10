using UnityEngine;

public class RegionManager : MonoBehaviour
{
    [SerializeField]
    private float safeTime;
    [SerializeField]
    private float dangerTime;
    [SerializeField]
    private Player player;

    private Player current;

    private void Start()
    {
        Invoke("End", safeTime + dangerTime);
        current = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (!current)
            current = Instantiate(player, transform.position, transform.rotation);
    }

    private void End() => GetComponent<Gate>().Warp();
}
