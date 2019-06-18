using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject trailEffect;

    private float speed;

    private Vector2 Position
    {
        get => rigidbody.position;
        set
        {
            rigidbody.position = value;
            transform.position = Position;
        }
    }

    private new Rigidbody2D rigidbody;
    private static readonly RaycastHit2D[] hits = new RaycastHit2D[20];

    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();

    public void Launch(float distance, float speed)
    {
        this.speed = speed;
        Invoke("Destroy", distance / speed);
    }

    private void FixedUpdate()
    {
        var distance = Time.fixedDeltaTime * speed;

        if (rigidbody.Cast(transform.up, hits, distance) > 0)
            Position += hits[0].fraction * (Vector2)transform.up;
        else
            Position += distance * (Vector2)transform.up;
    }

    public void Destroy()
    {
        trailEffect.transform.parent = null;
        Destroy(trailEffect, 2);
        Destroy(gameObject);
        if (hitEffect)
            Instantiate(hitEffect, Position, transform.rotation);
    }
}
