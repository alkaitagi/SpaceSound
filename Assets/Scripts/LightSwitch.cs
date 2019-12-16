using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private bool isOn;
    public bool IsOn { get => isOn; set => isOn = value; }
    [SerializeField]
    private float fadeSpeed;

    private new Light2D light;

    private void Awake() => light = GetComponent<Light2D>();

    private void Update() => light.intensity = Mathf.Clamp01(light.intensity
                                                             + (IsOn ? 1 : -1)
                                                             * fadeSpeed
                                                             * Time.deltaTime);

    public void Switch() => IsOn = !IsOn;
}
