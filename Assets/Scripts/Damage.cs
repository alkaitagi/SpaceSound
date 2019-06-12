using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private UnitType target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() is Health health && health.Type == target)
            health.Destroy();
    }
}
