using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private Engine mainEngine;
    [SerializeField]
    private Engine leftTorque;
    [SerializeField]
    private Engine rightTorque;
    [SerializeField]
    private float rotationSpeed;

    #region modules

    [Header("Modules")]
    [SerializeField]
    private new GameObject light;
    [SerializeField]
    private Thruster thruster;
    [SerializeField]
    private Cannon cannon;

    public void UpdateModules()
    {
        light.SetActive(ModuleManager.hasLight);
        thruster.gameObject.SetActive(ModuleManager.hasThruster);
        cannon.gameObject.SetActive(ModuleManager.hasCannon);
    }

    #endregion

    public static Player Main { get; private set; }
    public static Vector3 Position => Main.transform.position;

    private void Awake() => Main = this;

    private void Start()
    {
        CameraManager.VirtualCamera.Follow = transform;
        UpdateModules();
    }

    private void Update()
    {
        mainEngine.IsOn = Input.GetKey("w");
        leftTorque.IsOn = Input.GetKey("a");
        rightTorque.IsOn = Input.GetKey("d");

        transform.rotation = Quaternion.Euler
        (
            0,
            0,
            Mathf.LerpAngle
            (
                transform.eulerAngles.z,
                -Vector2.SignedAngle
                (
                    CameraManager.MouseWorld() - transform.position,
                    Vector3.up
                ),
                rotationSpeed * Time.deltaTime
            )
        );

        if (Input.GetKeyDown("space"))
            if (thruster.gameObject.activeInHierarchy)
                thruster.Burst();
            else if (cannon.gameObject.activeInHierarchy)
                cannon.Shoot();
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        mainEngine.IsOn = false;
        leftTorque.IsOn = false;
        rightTorque.IsOn = false;
    }
}
