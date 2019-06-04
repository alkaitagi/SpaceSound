using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private Door door;
    [SerializeField]
    private VoidEvent onActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Activate();
    }

    private void Awake()
    {
        if (door)
            door.Keys++;
    }

    public void Activate()
    {
        if (door)
            door.Keys--;
        onActivate.Invoke();
        //Destroy(gameObject);
    }
}