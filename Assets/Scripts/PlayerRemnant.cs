using UnityEngine;

public class PlayerRemnant : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Player player;

    private Vector3 Destination =>
        RegionManager.Main.transform.position;

    private void Start()
    {
        CameraManager.VirtualCamera.Follow = transform;
        transform.localEulerAngles = new Vector3
        (
            0,
            0,
            Vector2.SignedAngle(transform.up, Destination - transform.position)
        );
    }

    private void FixedUpdate()
    {
        if (RegionManager.Main && !Player.Main)
        {
            transform.position = Vector2.MoveTowards
            (
                transform.position,
                RegionManager.Main.transform.position,
                speed * Time.fixedDeltaTime
            );
            if ((transform.position - RegionManager.Main.transform.position).sqrMagnitude <= .25f)
            {
                Instantiate(player, Destination, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
