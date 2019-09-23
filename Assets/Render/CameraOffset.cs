using UnityEngine;

using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraOffset : MonoBehaviour
{
    [SerializeField, Range(.05f, 1)]
    private float offset = .1f;
    [SerializeField, Range(.05f, 1)]
    private float limit = .9f;

    private CinemachineFramingTransposer transposer;

    private void Awake() => transposer =
        GetComponent<CinemachineVirtualCamera>()
            .GetCinemachineComponent<CinemachineFramingTransposer>();

    private void OnDisable()
    {
        transposer.m_ScreenX = .5f;
        transposer.m_ScreenY = .5f;
    }

    private void Update()
    {
        var screen = new Vector2(Screen.width, Screen.height);
        var radius = limit * Mathf.Min(screen.x, screen.y);

        var position = (Vector2)Input.mousePosition - screen / 2;
        if (position.magnitude > radius)
            position = radius * position.normalized;

        var percent = new Vector2(position.x / screen.x, position.y / screen.y);

        transposer.m_ScreenX = .5f - offset * percent.x;
        transposer.m_ScreenY = .5f + offset * percent.y;
    }
}
