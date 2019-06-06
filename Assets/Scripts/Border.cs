using System.Linq;

using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Border : MonoBehaviour
{
    [SerializeField]
    private int points;

    public void Generate() =>
        GetComponent<EdgeCollider2D>().points = Enumerable
            .Range(0, points + 1)
            .Select(i => Mathf.Deg2Rad * 360 / points * i)
            .Select(a => new Vector2(Mathf.Cos(a), Mathf.Sin(a)))
            .ToArray();
}
