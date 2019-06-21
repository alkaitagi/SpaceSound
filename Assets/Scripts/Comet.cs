using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField]
    private Range speed;
    [SerializeField]
    private float pushScale;
    [SerializeField]
    private Transform center;

    private Vector2 GetDirection() =>
        Vector2.Perpendicular((transform.position - center.position).normalized);

    private void Start() => speed.Evaluate();

    private void FixedUpdate() =>
        transform.position =
            (Vector2)transform.position
            + speed.Value * Time.fixedDeltaTime * GetDirection();

    private void OnTriggerEnter2D(Collider2D other) => Push(other.attachedRigidbody);

    private void OnCollisionEnter2D(Collision2D other) => Push(other.rigidbody);

    private void Push(Rigidbody2D target)
    {
        if (target)
            target.AddForce
            (
                pushScale * speed.Value * GetDirection(),
                ForceMode2D.Impulse
            );
    }
}
