using UnityEngine;

public static class Extensions
{
    public static ParticleSystem Emission(this ParticleSystem particleSystem, bool value)
    {
        var emission = particleSystem.emission;
        emission.enabled = value;
        return particleSystem;
    }

    public static ParticleSystem Loop(this ParticleSystem particleSystem, bool value)
    {
        var main = particleSystem.main;
        main.loop = value;
        return particleSystem;
    }

    public static void Clear(this Transform transform, bool isImmediate = false)
    {
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            var child = transform.GetChild(0);
            child.parent = null;

            if (isImmediate)
                Object.DestroyImmediate(child.gameObject);
            else
                Object.Destroy(child.gameObject);
        }
    }
}
