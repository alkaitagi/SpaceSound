using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRemnant : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Player player;

    private new Rigidbody2D rigidbody;

    private void Awake() =>
        rigidbody = GetComponent<Rigidbody2D>();

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
        if (!RegionManager.Main || Player.Main)
            return;

        var next = Vector2.MoveTowards
        (
            rigidbody.position,
            RegionManager.Main.transform.position,
            speed * Time.fixedDeltaTime
        );
        rigidbody.MovePosition(next);
        Player.Position = next;

        if (next == (Vector2)RegionManager.Main.transform.position)
        {
            Instantiate(player, Destination, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
