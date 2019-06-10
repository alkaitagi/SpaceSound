using System.Linq;

using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private Range speed;

    private Transform target;

    private void Awake() => speed.Evaluate();

    private void Update()
    {
        if (target)
            transform.position = Vector2.MoveTowards
            (
                transform.position,
                target.position,
                speed.Random() * Time.deltaTime
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Waypoint>() is Waypoint waypoint && waypoint.Connections.Count > 0)
            target = waypoint.Connections[Random.Range(0, waypoint.Connections.Count)];
    }
}
