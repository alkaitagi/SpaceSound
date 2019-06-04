using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private float radialSpeed;
    [SerializeField]
    private float angularSpeed;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() is Rigidbody2D rigidbody)
        {
            var direction = ((Vector2)transform.position - rigidbody.position).normalized;
            rigidbody.velocity += radialSpeed * direction + angularSpeed * Vector2.Perpendicular(direction);
        }
    }
}