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

    [Header("Rotation")]
    [SerializeField]
    private float angleRange;
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

    private new Camera camera;

    private void Awake() => camera = Camera.main;

    private void Start() => UpdateModules();

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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

        if (Input.GetMouseButton(0) && cannon.gameObject.activeInHierarchy)
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
