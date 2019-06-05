using UnityEngine;

public static class Extensions
{
    public static void Toggle(this ParticleSystem particleSystem, bool isOn)
    {
        var emission = particleSystem.emission;
        emission.enabled = isOn;
    }

    public static void Clear(this Transform transform, bool isImmediate = false)
    {
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            var child = transform.GetChild(0);
            child.parent = null;

            if (isImmediate)
                GameObject.DestroyImmediate(child.gameObject);
            else
                GameObject.Destroy(child.gameObject);
        }
    }
}
