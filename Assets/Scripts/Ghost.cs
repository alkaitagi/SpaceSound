using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioEchoFilter))]
public class Ghost : MonoBehaviour
{
    [SerializeField]
    private Range speed;

    [Space(10)]
    [SerializeField]
    private Range audioPitch;
    [SerializeField]
    private Range echoDelay;

    private Transform target;
    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        speed.Evaluate();
        rigidbody = GetComponent<Rigidbody2D>();

        GetComponent<AudioSource>().pitch = audioPitch.Random();
        GetComponent<AudioEchoFilter>().delay = echoDelay.Random();
    }

    private void FixedUpdate()
    {
        if (target)
            rigidbody.MovePosition
            (
                Vector2.MoveTowards
                (
                    transform.position,
                    target.position,
                    speed.Random() * Time.fixedDeltaTime
                )
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Waypoint>() is Waypoint waypoint && waypoint.Connections.Count > 0)
            target = waypoint.Connections[Random.Range(0, waypoint.Connections.Count)];
    }
}
