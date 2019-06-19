using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject spear;

    public void UpdateModules()
    {
        light.SetActive(ModuleManager.hasLight);
        thruster.gameObject.SetActive(ModuleManager.hasThruster);
        spear.gameObject.SetActive(ModuleManager.hasCannon);
    }

    #endregion

    public static Player Main { get; private set; }

    private void Awake() => Main = this;

    private void Start()
    {
        CameraManager.VirtualCamera.Follow = transform;
        UpdateModules();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown("r"))
            SceneManager.LoadScene("Main");

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

        if (Input.GetKeyDown("space") && thruster.gameObject.activeInHierarchy)
            thruster.Burst();
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        mainEngine.IsOn = false;
        leftTorque.IsOn = false;
        rightTorque.IsOn = false;
    }
}
