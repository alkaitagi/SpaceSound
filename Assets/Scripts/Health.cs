using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;

    public void Destroy()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
