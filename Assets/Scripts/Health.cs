using UnityEngine;

public enum UnitType
{
    Player,
    Enemy
}

public class Health : MonoBehaviour
{
    [SerializeField]
    private UnitType type;
    public UnitType Type => type;
    [SerializeField]
    private float startInvulnerability;

    [Space(10)]
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private VoidEvent onDestroy;
    public VoidEvent OnDestroy => onDestroy;

    private void Update() =>
        startInvulnerability = Mathf.Max(0, startInvulnerability - Time.deltaTime);

    public void Destroy()
    {
        if (startInvulnerability == 0)
        {
            if (effect)
                Instantiate(effect, transform.position, transform.rotation);
            OnDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
