using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject trailEffect;

    private float damage;
    private float speed;

    private new Rigidbody2D rigidbody;
    private static readonly RaycastHit2D[] hits = new RaycastHit2D[20];

    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();

    public void Launch(float damage, float distance, float speed)
    {
        this.damage = damage;
        this.speed = speed;
        Invoke("Destroy", distance / speed);
    }

    private void FixedUpdate()
    {
        var distance = Time.fixedDeltaTime * speed;
        var destination = transform.position + transform.up * distance;

        if (rigidbody.Cast(transform.up, hits, distance) > 0)
        {
            rigidbody.MovePosition(hits[0].point);
            Destroy();
        }
        else
            rigidbody.MovePosition(destination);
    }

    private void Destroy()
    {
        trailEffect.transform.parent = null;
        Destroy(trailEffect, 2);
        Destroy(gameObject);
        Instantiate(hitEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy();
    }
}
