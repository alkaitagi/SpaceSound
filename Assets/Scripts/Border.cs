using System.Linq;

using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Border : MonoBehaviour
{
    public void Generate()
    {
        var points = (int)(.25f * Mathf.PI * transform.localScale.x);

        GetComponent<EdgeCollider2D>().points = Enumerable
            .Range(0, points + 1)
            .Select(i => Mathf.Deg2Rad * 360 / points * i)
            .Select(a => new Vector2(Mathf.Cos(a), Mathf.Sin(a)))
            .ToArray();

        var emission = GetComponent<ParticleSystem>().emission;
        emission.rateOverTime = 4 * points;
    }
}
