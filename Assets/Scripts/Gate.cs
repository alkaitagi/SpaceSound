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

    public bool IsLocked { get; private set; }

    [SerializeField]
    private GameObject effect;

    [Header("Warp")]
    [SerializeField]
    private string destination;
    public string Destination => destination;
    [SerializeField, Multiline]
    private string description;
    public string Description => description;

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
        if (!IsLocked)
        {
            Lock();
            WarpManager.Warp(this);
        }
    }

    public void Lock()
    {
        IsLocked = true;
        animator.SetTrigger("Lock");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Warp();
    }
}
