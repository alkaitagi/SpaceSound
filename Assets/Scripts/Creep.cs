using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Engine))]
public class Creep : MonoBehaviour
{
    [SerializeField]
    private Range turnSpeed;
    [SerializeField]
    private Range moveSpeed;

    private new Rigidbody2D rigidbody;
    private Engine engine;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        engine = GetComponent<Engine>();
    }

    private void Start()
    {
        turnSpeed.Evaluate();
        engine.Speed = moveSpeed.Random();
    }

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
                    turnSpeed.Value * Time.smoothDeltaTime
                )
            );
        }

        engine.IsOn = Player.Main;
    }
}
