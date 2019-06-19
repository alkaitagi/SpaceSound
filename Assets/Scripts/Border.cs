using System.Linq;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Border : MonoBehaviour
{
    [SerializeField]
    private float forceRadius;
    [SerializeField]
    private EdgeCollider2D forceEdge;
    [SerializeField]
    private ParticleSystem forceEffect;

    [Space(10)]
    [SerializeField]
    private float wallOffset;
    [SerializeField]
    private EdgeCollider2D wallEdge;

    public void Generate()
    {
        var forceScale = forceRadius * Vector3.one;
        var wallScale = (forceRadius + wallOffset) * Vector3.one;

        var points = (int)(.25f * Mathf.PI * forceRadius);

        forceEdge.transform.localScale = forceScale;
        wallEdge.transform.localScale = wallScale;

        forceEdge.points = wallEdge.points = Enumerable
            .Range(0, points + 1)
            .Select(i => Mathf.Deg2Rad * 360 / points * i)
            .Select(a => new Vector2(Mathf.Cos(a), Mathf.Sin(a)))
            .ToArray();

        forceEffect.transform.localScale = forceScale;
        var emission = forceEffect.emission;
        emission.rateOverTime = 4 * points;
    }
}


#if UNITY_EDITOR

[CanEditMultipleObjects]
[CustomEditor(typeof(Border))]
public class BorderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
            foreach (var target in targets)
                ((Border)target).Generate();
    }
}

#endif
