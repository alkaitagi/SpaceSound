using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private CanvasToggle canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            canvas.IsVisible = !canvas.IsVisible;
            Time.timeScale = canvas.IsVisible ? 0 : 1;
        }
    }
}
