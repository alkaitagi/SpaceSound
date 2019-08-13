using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Cannon : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float duration;
    [SerializeField]
    private UnitType target;

    [Space(10)]
    [SerializeField]
    private Transform spawn;
    [SerializeField]
    private ParticleSystem effect;

    private new AudioSource audio;

    private bool isReady = true;
    private void Ready() => isReady = true;

    private bool isShooting = false;
    private void Stop() => isShooting = false;

    private void Awake() => audio = GetComponent<AudioSource>();

    private void Start() => effect.transform.localScale = new Vector3(1, distance, 1);

    public void Shoot()
    {
        if (isReady)
        {
            isReady = false;
            Invoke("Ready", cooldown);

            isShooting = true;
            Invoke("Stop", duration);

            effect.Emit(Mathf.RoundToInt(20 * distance));
            audio.Play();
        }
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            var hit = Physics2D.CircleCast(spawn.position, .2f, spawn.up, distance);
            if (hit.collider?.GetComponent<Health>() is Health health)
                if (health.Type == target)
                {
                    health.Destroy();
                    Stop();
                }
        }
    }
}
