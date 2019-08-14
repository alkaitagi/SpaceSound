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
            Time.timeScale = canvas.IsVisible ? 0 : 1;
            MuteAudio(Time.timeScale == 0);
        }
    }

    private void MuteAudio(bool value)
    {
        foreach (var source in FindObjectsOfType(typeof(AudioSource)))
            ((AudioSource)source).mute = value;
    }
}
