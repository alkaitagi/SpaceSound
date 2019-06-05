using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Asteroid : MonoBehaviour
{
    [System.Serializable]
    private struct Range
    {
        public float min;
        public float max;

        public float Random() => UnityEngine.Random.Range(min, max);
    }

    [SerializeField]
    private Range scaleRange;
    [SerializeField]
    private Range rotationRange;
    [SerializeField]
    private Sprite[] sprites;

    private float rotation;

    private void Start() => Randomize();

    private void OnValidate() => Randomize();

    public void Randomize()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        transform.localScale = scaleRange.Random() * Vector3.one;
        rotation = rotationRange.Random();
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotation);
    }
}
