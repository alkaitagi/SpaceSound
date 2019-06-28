using UnityEngine;

[RequireComponent(typeof(CanvasToggle))]
public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Main { get; private set; }

    private CanvasToggle canvasToggle;

    private void Awake()
    {
        if (!Main)
        {
            Main = this;
            canvasToggle = GetComponent<CanvasToggle>();
        }
    }
}
