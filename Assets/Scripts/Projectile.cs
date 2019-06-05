using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private Transform trailEffect;

    private float damage;
    private float speed;

    private new Rigidbody2D rigidbody;

    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();

    public void Launch(float damage, float distance, float speed)
    {
        this.damage = damage;
        rigidbody.AddForce(speed * transform.up, ForceMode2D.Impulse);
        Invoke("Destroy", distance / speed);
    }

    private void Destroy()
    {
        Destroy(gameObject);
        trailEffect.transform.parent = null;
        Instantiate(hitEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy();
    }
}
