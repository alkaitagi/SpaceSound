using UnityEngine;

public class RegionManager : MonoBehaviour
{
    [SerializeField]
    private float safeTime;
    [SerializeField]
    private float dangerTime;
    [SerializeField]
    private float respawnTime;
    [SerializeField]
    private Player player;

    private Player current;

    private void Start()
    {
        Invoke("End", safeTime + dangerTime);
        current = FindObjectOfType<Player>();
    }

    private void Respawn()
    {
        current = Instantiate(player, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (!current && !IsInvoking("Respawn"))
            Invoke("Respawn", respawnTime);
    }

    private void End()
    {
        if (!current)
            Respawn();
        GetComponent<Gate>().Warp();
    }
}
