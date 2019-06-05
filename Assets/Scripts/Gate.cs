using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gate : MonoBehaviour
{
    private int keys;
    public int Keys
    {
        get => keys;
        set
        {
            keys = value;
            if (Keys <= 0)
                Open();
        }
    }

    [SerializeField]
    private Transform destination;
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private VoidEvent onJump;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void Start() => Keys = Keys;

    public void Open()
    {
        animator.SetTrigger("Open");
        Instantiate(effect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destination && other.CompareTag("Player"))
        {
            other.transform.position = destination.position;
            animator.SetTrigger("Lock");
            onJump.Invoke();
        }
    }
}