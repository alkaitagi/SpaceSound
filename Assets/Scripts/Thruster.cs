using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField]
    private float force;
    [SerializeField]
    private GameObject effect;

    private new Rigidbody2D rigidbody;

    private void Awake() => rigidbody = GetComponentInParent<Rigidbody2D>();

    public void Burst()
    {
        rigidbody.AddForce(force * transform.up, ForceMode2D.Impulse);
        Instantiate(effect, transform.position, transform.rotation);
    }
}