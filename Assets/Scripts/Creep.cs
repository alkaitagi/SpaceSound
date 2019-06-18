using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Creep : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float turnSpeed;

    private new Rigidbody2D rigidbody;

    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();

    private void Update()
    {
        if (Player.Main)
        {
            rigidbody.MoveRotation
            (
                Mathf.MoveTowardsAngle
                (
                    rigidbody.rotation,
                    Vector2.SignedAngle
                    (
                        Vector2.up,
                        (Player.Main.transform.position - transform.position).normalized
                    ),
                    turnSpeed * Time.smoothDeltaTime
                )
            );
            rigidbody.MovePosition
            (
                rigidbody.position +
                moveSpeed *
                Time.smoothDeltaTime *
                (Vector2)transform.up
            );
        }
    }
}
