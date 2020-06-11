using UnityEngine;
using UnityEngine.InputSystem;
using Sungazer.ShipModules;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerRemnant remnantReference;
    [SerializeField]
    private ObjectVariable moduleReference;

    [Header("Movement")]
    [SerializeField]
    private Engine mainEngine;
    [SerializeField]
    private Engine leftTorque;
    [SerializeField]
    private Engine rightTorque;
    [SerializeField]
    private float rotationSpeed;

    public static Player Main { get; private set; }
    public static Vector3 Position { get; set; }

    private BaseShipModule shipModule;

    private void Awake()
    {
        Main = this;
        CameraManager.VirtualCamera.Follow = transform;

        if (moduleReference.Value)
            shipModule = Instantiate(moduleReference.Value, transform)
                ?.GetComponent<BaseShipModule>();
    }

    public void SendRemnant() =>
        Instantiate(remnantReference, transform.position, Quaternion.identity);

    private void Update()
    {
        mainEngine.IsOn = Keyboard.current.wKey.isPressed;
        leftTorque.IsOn = Keyboard.current.aKey.isPressed;
        rightTorque.IsOn = Keyboard.current.dKey.isPressed;

        transform.rotation = Quaternion.Euler
        (
            0,
            0,
            Mathf.LerpAngle
            (
                transform.eulerAngles.z,
                -Vector2.SignedAngle
                (
                    CameraManager.MouseWorld - (Vector2)transform.position,
                    Vector3.up
                ),
                rotationSpeed * Time.deltaTime
            )
        );

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            shipModule?.Use();
    }

    private void FixedUpdate() =>
        Position = transform.position;

    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        mainEngine.IsOn = false;
        leftTorque.IsOn = false;
        rightTorque.IsOn = false;
    }
}
