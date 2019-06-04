using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Engine mainThrust;
    [SerializeField]
    private Engine leftTorque;
    [SerializeField]
    private Engine rightTorque;

    private void Update()
    {
        mainThrust.IsOn = Input.GetKey("w");
        leftTorque.IsOn = Input.GetKey("a");
        rightTorque.IsOn = Input.GetKey("d");
    }
}
