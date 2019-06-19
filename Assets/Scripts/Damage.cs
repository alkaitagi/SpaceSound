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
            if (destroySelf && GetComponent<Health>() is Health self)
                self.Destroy();
        }
    }
}
