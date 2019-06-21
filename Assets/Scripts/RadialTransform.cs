using System.Linq;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class RadialTransform : MonoBehaviour
{
    [SerializeField]
    private Range radius;
    [SerializeField]
    private float offset;
    [SerializeField]
    private Transform[] targetParents;

    [SerializeField]
    private bool updatePosition;
    [SerializeField]
    private bool updateRotation;
    [SerializeField]
    private bool noIntersections;

    [Space(10)]
    [SerializeField]
    private bool randomizeOnStart;

    private List<Transform> targets = new List<Transform>();

    private void Awake()
    {
        if (randomizeOnStart)
            Randomize();
    }

    private void GetTargets()
    {
        targets.Clear();
        if (targetParents == null || targetParents.Length == 0)
            foreach (Transform child in transform)
                targets.Add(child);
        else
            foreach (var parent in targetParents)
                foreach (Transform child in parent)
                    targets.Add(child);
    }

    public void Randomize()
    {
        GetTargets();
        Radialize();

        if (noIntersections)
        {
            Shuffle(targets);
            
            var radiusDelta = radius.Length / targets.Sum(t => t.lossyScale.x);
            var currentRadius = radius.Min;

            foreach (var target in targets)
                target.position =
                    transform.position
                    + (currentRadius += target.lossyScale.x * radiusDelta)
                    * (target.position - transform.position).normalized;
        }
    }

    private void Radialize()
    {
        var arc = 360f / targets.Count;
        for (int i = 0; i < targets.Count; i++)
        {
            var angle = Mathf.Deg2Rad * (offset + arc * i);
            var child = targets[i];

            if (updatePosition)
                child.localPosition = radius.Random() * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (updateRotation)
                child.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle + 90);
        }
    }

    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

#if UNITY_EDITOR

[CanEditMultipleObjects]
[CustomEditor(typeof(RadialTransform))]
public class RadialTransformEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Randomize"))
            foreach (var target in targets)
                ((RadialTransform)target).Randomize();
    }
}

#endif
