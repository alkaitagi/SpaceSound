using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Engine))]
public class Creep : MonoBehaviour
{
    [SerializeField]
    private Range turnSpeed;
    [SerializeField]
    private Range moveSpeed;

    [Header("Detection")]
    [SerializeField]
    private Transform safeArea;
    [SerializeField]
    private float safeAreaRange;
    [SerializeField]
    private float detectionRange;

    private new Rigidbody2D rigidbody;
    private Engine engine;

    private Vector3 spawn;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        engine = GetComponent<Engine>();
    }

    private void Start()
    {
        spawn = transform.position;
        Randomize();
    }

    private void Randomize()
    {
        turnSpeed.Evaluate();
        moveSpeed.Evaluate();
        engine.Speed = moveSpeed.Value;
    }

    private void Update() =>
        Move
        (
            !Player.Main
            || (spawn - Player.Position).magnitude > detectionRange
            || safeArea && (safeArea.position - Player.Position).magnitude <= safeAreaRange
            ? spawn
            : Player.Position
        );

    private void Move(Vector3 target) =>
            rigidbody.MoveRotation
            (
                Mathf.MoveTowardsAngle
                (
                    rigidbody.rotation,
                    Vector2.SignedAngle
                    (
                        Vector2.up,
                        (target - transform.position).normalized
                    ),
                    turnSpeed.Value * Time.smoothDeltaTime
                )
            );
}
