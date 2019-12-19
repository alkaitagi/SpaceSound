using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private bool active;
    public bool Active
    {
        get => active;
        set
        {
            if (Locked && value)
                return;
            active = value;
            onActiveChange.Invoke(Active);
        }
    }
    [SerializeField]
    private BoolEvent onActiveChange;

    [Space(10)]
    [SerializeField]
    private float fadeSpeed;
    [SerializeField]
    private bool locked;
    public bool Locked
    {
        get => locked;
        set
        {
            if (value)
                Active = false;
            locked = value;
            if (lockEffect)
                lockEffect.Emission(Locked);
        }
    }
    [SerializeField]
    private ParticleSystem lockEffect;

    private new Light2D light;

    private void Awake() => light = GetComponent<Light2D>();

    private void Start()
    {
        Locked = Locked;
        light.intensity = Active ? 1 : 0;
    }

    private void Update() => light.intensity = Mathf.Clamp01(light.intensity
                                                             + (Active ? 1 : -1)
                                                             * fadeSpeed
                                                             * Time.deltaTime);

    public void ToggleActive() => Active = !Active;
    public void ToggleLocked() => Locked = !Locked;
}
