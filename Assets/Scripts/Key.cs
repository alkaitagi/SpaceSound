using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(ParticleSystem))]
public class Key : MonoBehaviour
{
    [SerializeField]
    private Gate gate;
    [SerializeField]
    private GameObject effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Activate();
    }

    private void Awake()
    {
        if (gate)
            gate.Keys++;
    }

    public void Activate()
    {
        if (gate)
            gate.Keys--;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<ParticleSystem>().Toggle(false);

        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject, 1);
    }
}