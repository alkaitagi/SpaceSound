using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float maxAngle;

    private new Camera camera;

    private void Awake() => camera = Camera.main;

    private void Update()
    {
        var mousePosition = GetMousePosition();
        var angle = Vector2.SignedAngle(mousePosition - transform.position, transform.parent.up);
        transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(-angle, -maxAngle, maxAngle));
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.forward, Vector3.zero).Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }
}
