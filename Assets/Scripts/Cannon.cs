using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float cooldown;

    [Space(10)]
    [SerializeField]
    private Projectile projectile;

    private bool isReady = true;
    private void Ready() => isReady = true;

    public void Shoot()
    {
        if (isReady)
        {
            isReady = false;
            Invoke("Ready", cooldown);

            var projectile = Instantiate(this.projectile, transform.position, transform.rotation);
            projectile.Launch(damage, distance, speed);
        }
    }
}
