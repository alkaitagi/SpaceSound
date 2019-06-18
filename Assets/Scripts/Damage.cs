using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private UnitType target;
    [SerializeField]
    private bool destroySelf;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() is Health health && health.Type == target)
        {
            health.Destroy();
            if (destroySelf)
                if (GetComponent<Health>() is Health hlt)
                    hlt.Destroy();
                else if (GetComponent<Projectile>() is Projectile prj)
                    prj.Destroy();
        }
    }
}
