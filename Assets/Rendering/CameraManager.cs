using UnityEngine;

using Cinemachine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraManager : MonoBehaviour
{
    public static CameraManager Main { get; private set; }
    public static Camera Camera { get; private set; }
    public static CinemachineVirtualCamera VirtualCamera { get; private set; }

    private void Awake()
    {
        Main = this;
        Camera = GetComponent<Camera>();
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public static Vector3 MouseWorld()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.forward, Vector3.zero).Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }
}
