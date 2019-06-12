using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Impulse : MonoBehaviour
{
    [SerializeField]
    private Range scale;
    [SerializeField]
    private float errorAngle;
    [SerializeField]
    private Transform target;

    private void Start()
        => GetComponent<Rigidbody2D>()
            .AddForce
            (
                scale.Random() *
                (
                    Quaternion.Euler(0, 0, Random.Range(-errorAngle, errorAngle))
                    * Vector2.Perpendicular(target.position - transform.position)
                ).normalized,
                ForceMode2D.Impulse
            );
}
