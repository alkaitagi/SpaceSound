using UnityEngine;

public class PlayerRemnant : MonoBehaviour
{
    [Space(10)]
    private float speed;
    [SerializeField]
    private Player player;

    private Vector3 Destination => RegionManager.Main.transform.position;

    private void Start()
    {
        CameraManager.VirtualCamera.Follow = transform;
        transform.localEulerAngles = new Vector3
        (
            0,
            0,
            Vector2.SignedAngle(transform.up, transform.position - Destination)
        );
    }

    private void Update()
    {
        if (RegionManager.Main && !Player.Main)
        {
            transform.position = Vector2.MoveTowards
            (
                transform.position,
                RegionManager.Main.transform.position,
                speed * Time.smoothDeltaTime
            );
            if ((transform.position - RegionManager.Main.transform.position).sqrMagnitude <= .25f)
            {
                Instantiate(player, transform.position, transform.rotation);
                Destroy(this);
                Destroy(gameObject, 5);
            }
        }
    }
}
