using System.Linq;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(SpriteRenderer))]
public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private List<Transform> connections;
    public List<Transform> Connections => connections;

    private void Awake() => GetComponent<SpriteRenderer>().enabled = false;

    private void OnDrawGizmosSelected()
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

#if UNITY_EDITOR

[CanEditMultipleObjects]
[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Connect"))
            foreach (var target in targets)
                ((Waypoint)target).Connect();
    }
}

#endif
