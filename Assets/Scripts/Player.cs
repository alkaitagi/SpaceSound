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

    [Header("Modules")]
    [SerializeField]
    private Burst burst;

    private void Update()
    {
        mainThrust.IsOn = Input.GetKey("w");
        leftTorque.IsOn = Input.GetKey("a");
        rightTorque.IsOn = Input.GetKey("d");

        if (Input.GetKeyDown("space"))
            burst.Apply();
    }
}
