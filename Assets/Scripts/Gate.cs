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

    [Space(10)]
    [SerializeField]
    private string destination;
    [SerializeField]
    private VoidEvent onWarp;

    [Space(10)]
    [SerializeField]
    private AudioSource audioPulse;
    [SerializeField]
    private AudioSource audioClose;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void Start() => Keys = Keys;

    public void Open()
    {
        animator.SetTrigger("Open");
        audioPulse.Play();
    }

    public void Warp()
    {
        if (!IsLocked)
        {
            Lock();
            onWarp.Invoke();
            WarpManager.Warp(destination);
        }
    }

    public void Lock()
    {
        IsLocked = true;
        animator.SetTrigger("Lock");
        audioPulse.Stop();
        audioClose.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Warp();
    }
}
