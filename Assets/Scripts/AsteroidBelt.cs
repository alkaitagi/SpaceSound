using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    [SerializeField]
    private Range radiusRange;
    [SerializeField]
    private int count;
    [SerializeField]
    private Asteroid sourceAsteroid;

    public void Generate()
    {
        transform.Clear(true);

        for (int i = 0; i < count; i++)
        {
            var instance = Instantiate(sourceAsteroid, transform);
            instance.Generate();
            instance.transform.localPosition = radiusRange.Random() * Random.insideUnitCircle.normalized;
        }
    }
}
