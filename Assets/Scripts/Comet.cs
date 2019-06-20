using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Comet : MonoBehaviour
{
    [SerializeField]
    private Range startImpulse;
    [SerializeField]
    private float pushScale;
    [SerializeField]
    private GameObject effect;

    private new Rigidbody2D rigidbody;

    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();

    private void Start() => rigidbody.AddForce
    (
        startImpulse.Random() * Random.insideUnitCircle.normalized,
        ForceMode2D.Impulse
    );

    private void OnTriggerEnter2D(Collider2D other) => Push(other.attachedRigidbody);

    private void OnCollisionEnter2D(Collision2D other) => Push(other.rigidbody);

    private void Push(Rigidbody2D target)
    {
        if (target)
        {
            var force = pushScale * rigidbody.velocity.normalized;
            if (target.GetComponent<Comet>())
            {
                var normal = (target.position - rigidbody.position).normalized;

                Instantiate
                (
                    effect,
                    transform.position,
                    Quaternion.FromToRotation(normal, Vector2.up)
                );

                target.velocity = Vector2.Reflect(force, normal);
            }
            else if (target.GetComponent<Player>())
                target.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
