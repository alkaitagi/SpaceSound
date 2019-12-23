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
            active = value;
            onActiveChange.Invoke(Active);
        }
    }
    [SerializeField]
    private BoolEvent onActiveChange;

    [Space(10)]
    [SerializeField]
    private float activeIntensity;
    [SerializeField]
    private float clapmedIntensity;
    [SerializeField]
    private float inactiveIntensity;

    [Space(10)]
    [SerializeField]
    private float fadeSpeed;
    [SerializeField]
    private bool clamped;
    public bool Clamped
    {
        get => clamped;
        set
        {
            clamped = value;
            if (clampEffect)
                clampEffect.Emission(Clamped);
        }
    }
    [SerializeField]
    private ParticleSystem clampEffect;

    private new Light2D light;

    private void Awake() => light = GetComponent<Light2D>();

    private void Start()
    {
        Clamped = Clamped;
        light.intensity = TargetIntensity;
    }

    private void Update() => light.intensity = Mathf.MoveTowards(light.intensity,
                                                                 TargetIntensity,
                                                                 fadeSpeed * Time.deltaTime);

    public void ToggleActive() => Active = !Active;
    public void ToggleClamped() => Clamped = !Clamped;

    private float TargetIntensity =>
        Active
            ? (Clamped ? clapmedIntensity : activeIntensity)
            : 0;
}
