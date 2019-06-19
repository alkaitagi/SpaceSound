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
    private GameObject effect;
    [SerializeField]
    private GameObject loot;

    private void Awake()
    {
        if (loot)
            loot.SetActive(false);
    }

    public void Destroy()
    {
        if (effect)
            Instantiate(effect, transform.position, transform.rotation);
        if (loot)
        {
            loot.SetActive(true);
            loot.transform.parent = null;
            loot.transform.position = transform.position;
            loot.transform.localScale = Vector3.one;
        }
        Destroy(gameObject);
    }
}
