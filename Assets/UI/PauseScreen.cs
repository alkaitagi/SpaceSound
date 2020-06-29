using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private CanvasToggle canvas;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            canvas.IsVisible = !canvas.IsVisible;
            AudioListener.pause = canvas.IsVisible;
            Time.timeScale = canvas.IsVisible ? 0 : 1;
        }
    }
}
