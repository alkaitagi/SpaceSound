using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioEchoFilter))]
public class Ghost : MonoBehaviour
{
    [SerializeField]
    private Range speed;
    [SerializeField]
    private Range reactionDelay;
    public float ReactionDelay => reactionDelay.Value;
    [SerializeField]
    private ParticleSystem reactionEffect;
    [SerializeField]
    private LightSwitch reactionLight;

    [Space(10)]
    [SerializeField]
    private Range echoDelay;
    [SerializeField]
    private Range pitch;

    private Transform waypoint;
    private Vector3? target;

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        speed.Evaluate();
        reactionDelay.Evaluate();

        rigidbody = GetComponent<Rigidbody2D>();

        GetComponent<AudioEchoFilter>().delay = echoDelay.Random();
        GetComponent<AudioSource>().pitch = pitch.Random();
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

    public IEnumerator Trigger(Vector3 position)
    {
        reactionEffect.Toggle(true);
        reactionLight.IsOn = true;

        var waypoint = this.waypoint;
        this.waypoint = null;

        yield return new WaitForSeconds(ReactionDelay);
        target = position;

        yield return new WaitForSeconds((transform.position - position).magnitude / speed.Value);
        target = null;
        this.waypoint = waypoint;

        reactionEffect.Toggle(false);
        reactionLight.IsOn = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Waypoint>() is Waypoint waypoint
            && waypoint.Connections.Count > 0)
            this.waypoint = waypoint.Connections[Random.Range(0, waypoint.Connections.Count)];
    }
}
