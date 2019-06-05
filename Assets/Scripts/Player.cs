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

    [Header("Turret")]
    [SerializeField]
    private float angleRange;
    [SerializeField]
    private float rotationSpeed;

    [Header("Modules")]
    [SerializeField]
    private Transform turret;
    [SerializeField]
    private Thruster thruster;
    [SerializeField]
    private Cannon cannon;

    private new Camera camera;

    private void Awake() => camera = Camera.main;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        mainEngine.IsOn = Input.GetKey("w");
        leftTorque.IsOn = Input.GetKey("a");
        rightTorque.IsOn = Input.GetKey("d");

        turret.localRotation = Quaternion.Euler
        (
            0,
            0,
            Mathf.LerpAngle
            (
                turret.localEulerAngles.z,
                Mathf.Clamp
                (
                    -Vector2.SignedAngle
                    (
                        GetMousePosition() - turret.position,
                        turret.parent ? turret.parent.up : Vector3.up
                    ),
                    -angleRange,
                    angleRange
                ),
                rotationSpeed * Time.deltaTime
            )
        );

        if (Input.GetKeyDown("space") && thruster.gameObject.activeSelf)
            thruster.Burst();

        if (Input.GetMouseButton(0) && cannon.gameObject.activeSelf)
            cannon.Shoot();
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.forward, Vector3.zero).Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }
}
