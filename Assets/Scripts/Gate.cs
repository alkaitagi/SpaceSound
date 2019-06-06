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
    public Transform Destination => destination;
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private VoidEvent onWarp;
    public VoidEvent OnWarp => onWarp;

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
            other.attachedRigidbody.velocity = Vector2.zero;
            WarpManager.Main.Warp(this);
            animator.SetTrigger("Lock");
        }
    }
}