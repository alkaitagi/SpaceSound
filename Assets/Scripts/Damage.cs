using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private UnitType target;
    [SerializeField]
    private bool destroySelf;

    private void OnTriggerEnter2D(Collider2D other) =>
        Check(other.GetComponent<Health>());

    private void OnCollisionEnter2D(Collision2D other) =>
        Check(other.collider.GetComponent<Health>());

    private void Check(Health health)
    {
        if (health && health.Type == target)
        {
            health.Destroy();
            if (destroySelf && GetComponent<Health>() is Health self)
                self.Destroy();
        }
    }
}
