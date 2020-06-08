using System.Collections;
using UnityEngine;
using Sungazer.ShipModules;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioEchoFilter))]
public class Ghost : MonoBehaviour
{
    [SerializeField]
    private Range speed;

    [Space(10)]
    [SerializeField]
    private Range reactionDelay;
    [SerializeField]
    private ParticleSystem reactionEffect;
    [SerializeField]
    private LightShipModule reactionLight;

    [Space(10)]
    [SerializeField]
    private Range echoDelay;

    private Transform waypoint;
    private Vector3? target = null;
    private bool charging;

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        speed.Evaluate();
        reactionDelay.Evaluate();

        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<AudioEchoFilter>().delay = echoDelay.Random();
    }

    private void FixedUpdate() =>
        rigidbody.MovePosition
        (
            Vector2.MoveTowards
            (
                transform.position,
                target.HasValue
                    ? target.Value
                    : (waypoint ?? transform).position,
                speed.Random() * Time.fixedDeltaTime
            )
        );

    public void Trigger(Vector3 position)
    {
        if (charging)
            return;

        StopAllCoroutines();
        StartCoroutine(Charge(position));
    }

    private IEnumerator Charge(Vector3 position)
    {
        charging = true;

        reactionEffect.Emission(true);
        reactionLight.Active = true;

        var waypoint = this.waypoint;
        this.waypoint = null;

        yield return new WaitForSeconds(reactionDelay.Value);
        target = position;

        yield return new WaitForSeconds((transform.position - position).magnitude / speed.Value);
        target = null;
        this.waypoint = waypoint;

        reactionEffect.Emission(false);
        reactionLight.Active = false;

        charging = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Waypoint>() is Waypoint waypoint
            && waypoint.Connections.Count > 0)
            this.waypoint = waypoint.Connections[Random.Range(0, waypoint.Connections.Count)];

        if (other.CompareTag("Light"))
            Trigger(other.transform.position);
    }
}
