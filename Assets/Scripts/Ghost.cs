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

    public bool IsCharging { get; private set; }
    public float ChargeLevel { get; private set; }

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        speed.Evaluate();
        reactionDelay.Evaluate();

        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<AudioEchoFilter>().delay = echoDelay.Random();
    }

    private void FixedUpdate()
    {
        var next = Vector3.MoveTowards
        (
            transform.position,
            target.HasValue
                ? target.Value
                : (waypoint ?? transform).position,
            speed.Value * Time.fixedDeltaTime
        );

        transform.up = (next - transform.position).normalized;
        rigidbody.MovePosition(next);
    }

    public void Trigger(Vector3 position)
    {
        if (IsCharging)
            return;

        StopAllCoroutines();
        StartCoroutine(Charge(position));
    }

    private IEnumerator Charge(Vector3 position)
    {
        IsCharging = true;

        reactionEffect.Emission(true);
        reactionLight.Active = true;

        var waypoint = this.waypoint;
        this.waypoint = null;

        var offset = position - transform.position;
        var direction = offset.normalized;
        var distance = offset.magnitude;

        transform.up = direction;
        while (ChargeLevel < 1)
        {
            yield return new WaitForEndOfFrame();
            ChargeLevel += Time.deltaTime / reactionDelay.Value;
        }
        ChargeLevel = 1;
        target = position;

        yield return new WaitForSeconds(distance / speed.Value);

        target = null;
        this.waypoint = waypoint;

        reactionEffect.Emission(false);
        reactionLight.Active = false;

        IsCharging = false;
        ChargeLevel = 0;
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
