using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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

    private void Awake() => audio = GetComponent<AudioSource>();

    private void Start()
    {
        speed.Evaluate();
        radius = (transform.position - center.position).magnitude;
    }

    private void Update()
    {
        Vector3 destination =
            (Vector2)transform.position
            + speed.Value * Time.smoothDeltaTime
            * Vector2.Perpendicular((transform.position - center.position).normalized);

        transform.position =
            center.position
            + radius * (destination - center.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other) => Push(other.attachedRigidbody);

    private void OnCollisionEnter2D(Collision2D other) => Push(other.rigidbody);

    private void Push(Rigidbody2D target)
    {
        if (target)
        {
            target.AddForce
            (
                pushScale * speed.Value
                * (target.position - (Vector2)transform.position),
                ForceMode2D.Impulse
            );
            audio.Play();
        }
    }
}
