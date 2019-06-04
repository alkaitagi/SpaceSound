using UnityEngine;

public static class Extensions
{
    public static void Toggle(this ParticleSystem particleSystem, bool isOn)
    {
        var emission = particleSystem.emission;
        emission.enabled = isOn;
    }
}
