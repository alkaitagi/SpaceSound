using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TabSelect : MonoBehaviour
{
    [SerializeField]
    private CanvasToggle boundCanvas;

    private Selectable current;

    private void Start()
    {
        current = GetComponentInChildren<Selectable>();
        current?.Select();
    }

    private void Update()
    {
        if (!Keyboard.current.tabKey.wasPressedThisFrame)
            return;
        if (boundCanvas && !boundCanvas.IsVisible)
            return;

        var current = EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>();
        if (!current)
            if (this.current)
                current = this.current;
            else
                return;

        var next = Keyboard.current.leftShiftKey.isPressed
            ? current.FindSelectableOnUp()
            : current.FindSelectableOnDown();

        if (next)
        {
            next.Select();
            this.current = next;
        }
    }
}
