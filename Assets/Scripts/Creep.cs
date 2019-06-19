using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Engine))]
public class Creep : MonoBehaviour
{
    [SerializeField]
    private float detectionRange;
    [SerializeField]
    private Range bodyScale;
    [SerializeField]
    private Range turnSpeed;
    [SerializeField]
    private Range moveSpeed;

    private new Rigidbody2D rigidbody;
    private Engine engine;

    private Vector3 spawn;
    private Vector3 target;

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
        bodyScale.Evaluate();
        transform.localScale = bodyScale.Value * Vector3.one;
        turnSpeed.Lerp = moveSpeed.Lerp = 1 - bodyScale.Lerp;
        engine.Speed = moveSpeed.Value;
    }

    public bool IsInRange(Vector3 point) =>
        (transform.position - point).sqrMagnitude <= detectionRange * detectionRange;

    private void Update()
    {
        target = Player.Main && IsInRange(Player.Main.transform.position)
            ? Player.Main.transform.position
            : spawn;

        Move();
    }

    private void Move() =>
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
