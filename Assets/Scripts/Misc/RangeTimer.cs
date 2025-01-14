using UnityEngine;

public class RangeTimer : MonoBehaviour
{
    [SerializeField]
    private bool looping;
    [SerializeField]
    private Range interval;
    [SerializeField]
    private VoidEvent onTime;

    private void Start() => Next();

    private void Next() => Invoke("Time", interval.Random());

    private void Time()
    {
        onTime.Invoke();
        if (looping)
            Next();
    }

    public void Instantiate(GameObject gameObject) =>
        Instantiate(gameObject, transform.position, transform.rotation);
}
