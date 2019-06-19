using UnityEngine;

[ExecuteAlways]
public class RadialTransform : MonoBehaviour
{
    [SerializeField]
    private Range radius;
    [SerializeField]
    private float offset;
    [SerializeField]
    private bool updatePosition;
    [SerializeField]
    private bool updateRotation;

    private void Update()
    {
        var arc = 360f / transform.childCount;
        for (int i = 0; i < transform.childCount; i++)
        {
            var angle = Mathf.Deg2Rad * (offset + arc * i);
            var child = transform.GetChild(i);

            if (updatePosition)
                child.localPosition = radius.Random() * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (updateRotation)
                child.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle + 90);
        }
    }
}
