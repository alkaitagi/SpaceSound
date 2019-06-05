using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private Gate gate;
    [SerializeField]
    private VoidEvent onActivate;

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
        onActivate.Invoke();
        //Destroy(gameObject);
    }
}