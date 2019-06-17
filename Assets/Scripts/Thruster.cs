using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField]
    private float force;
    [SerializeField]
    private float cooldown;

    [Space(10)]
    [SerializeField]
    private GameObject effect;

    private new Rigidbody2D rigidbody;

    private void Awake() => rigidbody = GetComponentInParent<Rigidbody2D>();

    private bool isReady = true;
    private void Ready() => isReady = true;

    public void Burst()
    {
        if (isReady)
        {
            isReady = false;
            Invoke("Ready", cooldown);

            rigidbody.AddForce(force * transform.up, ForceMode2D.Impulse);
            Instantiate(effect, transform.position, transform.rotation);
        }
    }
}
