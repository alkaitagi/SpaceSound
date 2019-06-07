using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class UIUtility : ScriptableObject
{
    public static UIUtility Main { get; private set; }

    private void Awake() => Main = this;

    private void OnEnable() => Awake();

    #region UI

    public void Select(ToggleGroup group)
    {
        foreach (var toggle in group.ActiveToggles())
        {
            toggle.isOn = false;
            toggle.isOn = true;
            break;
        }
    }

    public void Click(Button button) => button.onClick.Invoke();

    public void Toggle(Toggle toggle) => toggle.isOn = !toggle.isOn;

    #endregion

    #region statics

    public static bool IsOverUI => EventSystem.current.IsPointerOverGameObject();

    public static bool IsInput => EventSystem.current.currentSelectedGameObject;

    #endregion

    #region openers

    public void Quit() => Application.Quit();

    public void LoadScene(string name) => SceneManager.LoadScene(name);

    public void ReloadScene() => LoadScene(SceneManager.GetActiveScene().name);

    public void OpenURL(string url) => Application.OpenURL(url);

    #endregion
}