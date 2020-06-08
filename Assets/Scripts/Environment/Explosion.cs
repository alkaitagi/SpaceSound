using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(UnityEngine.Experimental.Rendering.Universal.Light2D))]
public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed;

    private new Light2D light;

    private void Awake() =>
        light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();

    private void Update()
    {
        light.intensity = Mathf.MoveTowards(light.intensity, 0, fadeSpeed * Time.deltaTime);
        if (light.intensity <= 0)
            Destroy(gameObject);
    }
}
