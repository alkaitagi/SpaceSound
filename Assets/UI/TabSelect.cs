using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TabSelect : MonoBehaviour
{
    [SerializeField]
    private CanvasToggle boundCanvas;

    private bool IsBlocked => boundCanvas && !boundCanvas.IsVisible;
    private Selectable current;
    private Selectable[] children;

    private void Start()
    {
        children = GetComponentsInChildren<Selectable>();
        current = children.FirstOrDefault();
        if (!IsBlocked)
            current?.Select();
    }

    private void Update()
    {
        if (!Keyboard.current.tabKey.wasPressedThisFrame)
            return;
        if (IsBlocked)
            return;

        var current = EventSystem.current?.currentSelectedGameObject?.GetComponent<Selectable>();
        if (!current)
            if (this.current)
                current = this.current;
            else
                return;

        var next = Keyboard.current.leftShiftKey.isPressed
            ? current.FindSelectableOnUp()
            : current.FindSelectableOnDown();

        if (next && children.Contains(next))
        {
            next.Select();
            this.current = next;
        }
        else
            current.Select();
    }
}
