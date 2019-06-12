using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Comet : MonoBehaviour
{
    [SerializeField]
    private Range startScale;
    [SerializeField]
    private GameObject effect;

    private new Rigidbody2D rigidbody;

    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();

    private void Start()
         => rigidbody.AddForce
        (
            startScale.Random() * Random.insideUnitCircle.normalized,
            ForceMode2D.Impulse
        );

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Comet>())
        {
            var hit = (other.transform.position - transform.position).normalized;

            Instantiate
            (
                effect,
                transform.position,
                Quaternion.FromToRotation(hit, Vector2.up)
            );

            rigidbody.velocity =
                rigidbody.velocity.magnitude *
                Vector2.Reflect(hit, rigidbody.velocity);
        }
    }
}
