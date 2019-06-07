using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    [SerializeField]
    private Toggle toggleVSync;
    [SerializeField]
    private Dropdown dropdownFullscreenMode;

    private void Awake()
    {
        Application.targetFrameRate = 300;

        toggleVSync.onValueChanged.AddListener(SetVSync);
        toggleVSync.onValueChanged.Invoke(toggleVSync.isOn);

        dropdownFullscreenMode.onValueChanged.AddListener(SetFullscreenMode);
        dropdownFullscreenMode.onValueChanged.Invoke(dropdownFullscreenMode.value);
    }

    private void SetVSync(bool value) =>
        QualitySettings.vSyncCount = value ? 1 : 0;

    private void SetFullscreenMode(int value)
    {
        Resolution currentResolution = Screen.currentResolution;
        FullScreenMode fullScreenMode;

        if (value == 0)
            fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else if (value == 1)
            fullScreenMode = FullScreenMode.MaximizedWindow;
        else
            fullScreenMode = FullScreenMode.Windowed;

        Screen.SetResolution
        (
            currentResolution.width,
            currentResolution.height,
            fullScreenMode
        );
    }
}
