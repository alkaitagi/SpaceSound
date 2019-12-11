using UnityEngine;

public class RangeTimer : MonoBehaviour
{
    [SerializeField]
    private Range interval;
    [SerializeField]
    private VoidEvent onTime;

    private void Start() => Next();

    private void Next() => Invoke("Time", interval.Random());

    private void Time()
    {
        onTime.Invoke();
        Next();
    }

    public void Istantiate(GameObject source) =>
        Instantiate(source, transform.position, transform.rotation);
}
