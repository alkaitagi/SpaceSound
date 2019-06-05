using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float range;
    [SerializeField]
    private float speed;

    private new Camera camera;

    private void Awake() => camera = Camera.main;

    private void Update() =>
        transform.localRotation = Quaternion.Euler
        (
            0,
            0,
            Mathf.LerpAngle
            (
                transform.localEulerAngles.z,
                Mathf.Clamp
                (
                    -Vector2.SignedAngle
                    (
                        GetMousePosition() - transform.position,
                        transform.parent.up
                    ),
                    -range,
                    range
                ),
                speed * Time.deltaTime
            )
        );

    private Vector3 GetMousePosition()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.forward, Vector3.zero).Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }
}
