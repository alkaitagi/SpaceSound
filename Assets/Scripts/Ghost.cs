using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ghost : MonoBehaviour
{
    [SerializeField]
    private Range speed;

    private Transform target;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        speed.Evaluate();
        rigidbody = GetComponent<Rigidbody2D>();
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
