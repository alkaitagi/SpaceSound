using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Comet : MonoBehaviour
{
    [SerializeField]
    private Range speed;
    [SerializeField]
    private float pushScale;
    [SerializeField]
    private Transform center;

    private float radius;

    private new AudioSource audio;
    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed.Evaluate();
        radius = (transform.position - center.position).magnitude;
    }

    private void FixedUpdate()
    {
        Vector3 destination =
            (Vector2)transform.position
            + speed.Value * Time.fixedDeltaTime
            * Vector2.Perpendicular((transform.position - center.position).normalized);

        var position = rigidbody.position;
        var direction = (destination - center.position).normalized;

        rigidbody.MovePosition(center.position + radius * direction);
        transform.up = rigidbody.position - position;
    }

    private void OnTriggerEnter2D(Collider2D other) => Push(other.attachedRigidbody);

    private void OnCollisionEnter2D(Collision2D other) => Push(other.rigidbody);

    private void Push(Rigidbody2D target)
    {
        if (!target)
            return;

        target.AddForce
        (
            pushScale * speed.Value
            * (target.position - (Vector2)transform.position),
            ForceMode2D.Impulse
        );
        if (pushScale > 0 && audio)
            audio.Play();
    }
}
