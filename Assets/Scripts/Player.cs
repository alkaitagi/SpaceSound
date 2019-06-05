using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private Engine mainThrust;
    [SerializeField]
    private Engine leftTorque;
    [SerializeField]
    private Engine rightTorque;

    private Burst burst;

    private void Start()
    {
        UnlockBurst();
    }

    private void Update()
    {
        mainThrust.IsOn = Input.GetKey("w");
        leftTorque.IsOn = Input.GetKey("a");
        rightTorque.IsOn = Input.GetKey("d");

        if (burst && Input.GetKeyDown("space"))
            burst.Apply();
    }

    public void UnlockBurst() => burst = GetComponentInChildren<Burst>();
}
