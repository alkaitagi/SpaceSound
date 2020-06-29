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
    private float invulnerability;

    [Space(10)]
    [SerializeField]
    private ParticleSystem shieldEffect;
    [SerializeField]
    private new AudioSource audio;
    [SerializeField]
    private GameObject deathEffect;
    [SerializeField]
    private VoidEvent onDestroy;
    public VoidEvent OnDestroy => onDestroy;

    private void Update()
    {
        invulnerability = Mathf.Max(0, invulnerability - Time.deltaTime);
        if (shieldEffect)
        {
            var emission = shieldEffect.emission;
            emission.enabled = invulnerability > 0;

            if (!emission.enabled && audio)
                audio.Stop();
        }
    }

    public void Destroy(bool invulnerability = false)
    {
        if (invulnerability)
            this.invulnerability = 0;

        if (this.invulnerability == 0)
        {
            if (deathEffect)
                Instantiate(deathEffect, transform.position, transform.rotation);
            OnDestroy.Invoke();
            Destroy(gameObject);
        }
        else if (audio)
            audio.Play();
    }
}
