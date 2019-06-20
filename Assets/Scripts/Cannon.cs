using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private UnitType target;

    [Space(10)]
    [SerializeField]
    private Transform spawn;
    [SerializeField]
    private ParticleSystem effect;

    private bool isReady = true;
    private void Ready() => isReady = true;

    private void Start() => effect.transform.localScale = new Vector3(1, distance, 1);

    public void Shoot()
    {
        if (isReady)
        {
            isReady = false;
            Invoke("Ready", cooldown);

            Effect();
            foreach (var hit in Physics2D.CircleCastAll(spawn.position, .2f, spawn.up, distance))
                if (hit.collider.GetComponent<Health>() is Health health && health.Type == target)
                {
                    health.Destroy();
                    return;
                }
        }
    }

    private void Effect() => effect.Emit(Mathf.RoundToInt(20 * distance));
}
