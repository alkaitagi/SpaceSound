using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraManager : MonoBehaviour
{
    public static CameraManager Main { get; private set; }
    public static Camera Camera { get; private set; }
    public static CinemachineVirtualCamera VirtualCamera { get; private set; }

    public static Vector2 MouseWorld { get; private set; }
    public static Vector2 MouseScreen { get; private set; }

    private void Awake()
    {
        if (Main)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Main = this;
        Camera = GetComponent<Camera>();
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update() =>
        UpdateMouse();

    private void UpdateMouse()
    {
        MouseScreen = Mouse.current.position.ReadValue();
        Ray ray = Camera.ScreenPointToRay(MouseScreen);
        new Plane(Vector3.forward, Vector3.zero).Raycast(ray, out float distance);
        MouseWorld = ray.GetPoint(distance);
    }
}
