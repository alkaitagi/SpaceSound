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

    private void Start() => Invoke("End", safeTime + dangerTime);

    private void Respawn() => Instantiate(player, transform.position, transform.rotation);

    private void Update()
    {
        if (!Player.Main && !IsInvoking("Respawn"))
            Invoke("Respawn", respawnTime);
    }

    private void End()
    {
        var gate = GetComponent<Gate>();
        if (!gate.IsLocked)
        {
            if (!Player.Main)
                Respawn();
            gate.Warp();
        }
    }
}
