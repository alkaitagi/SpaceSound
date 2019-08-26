using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private CanvasToggle canvas;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            canvas.IsVisible = !canvas.IsVisible;
            AudioListener.pause = canvas.IsVisible;
            Time.timeScale = canvas.IsVisible ? 0 : 1;
        }
    }
}
