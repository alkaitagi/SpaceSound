using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private CanvasToggle canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.IsVisible = !canvas.IsVisible;
            Time.timeScale = canvas.IsVisible ? 0 : 1;
        }
    }
}
