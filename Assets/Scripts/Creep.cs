using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Engine))]
public class Creep : MonoBehaviour
{
    
    [SerializeField]
    private Range bodyScale;
    [SerializeField]
    private Range turnSpeed;
    [SerializeField]
    private Range moveSpeed;

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
        bodyScale.Evaluate();
        transform.localScale = bodyScale.Value * Vector3.one;
        turnSpeed.Lerp = moveSpeed.Lerp = 1 - bodyScale.Lerp;
        engine.Speed = moveSpeed.Value;
    }

    private void Update() =>
        Move(Player.Main ? Player.Main.transform.position : spawn);

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
