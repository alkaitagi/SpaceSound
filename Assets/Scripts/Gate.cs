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

    [Header("Events")]
    [SerializeField]
    private VoidEvent onWarpIn;
    public VoidEvent OnWarpIn => onWarpIn;
    [SerializeField]
    private bool isInterrupted;
    public bool IsInterrupted => isInterrupted;
    [SerializeField]
    private VoidEvent onInterrupt;
    public VoidEvent OnInterrupt => onInterrupt;
    [SerializeField]
    private VoidEvent onWarpOut;
    public VoidEvent OnWarpOut => onWarpOut;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void Start() => Keys = Keys;

    public void Open()
    {
        animator.SetTrigger("Open");
        Instantiate(effect, transform.position, transform.rotation);
    }

    public void Warp()
    {
        WarpManager.Main.Warp(this);
        animator.SetTrigger("Lock");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destination && other.CompareTag("Player"))
            Warp();
    }
}