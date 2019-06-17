using System.Linq;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private List<Transform> connections;
    public List<Transform> Connections => connections;

    private void Awake() => GetComponent<SpriteRenderer>().enabled = false;

    private void OnDrawGizmos()
    {
        foreach (var connection in Connections)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, connection.position);
        }
    }

    public void Connect()
    {
        Connections.Clear();
        Connections.AddRange
        (
            Physics2D
            .OverlapCircleAll(transform.position, distance, LayerMask.GetMask("Effect"))
            .Where(c => c.GetComponent<Waypoint>())
            .Select(c => c.transform)
            .Where(t => t != transform)
            .Where(t => !Physics2D.Linecast(transform.position, t.position, LayerMask.GetMask("Environment")))
        );
    }
}
