using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Turret : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private Cannon cannon;

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

            if (cannon.IsInRange(Player.Main.transform.position))
                cannon.Shoot();
        }
    }
}