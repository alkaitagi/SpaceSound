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

    public void Destroy()
    {
        if (effect)
            Instantiate(effect, transform.position, transform.rotation);
        if (loot)
        {
            loot.SetActive(true);
            loot.transform.parent = null;
        }
        Destroy(gameObject);
    }
}
