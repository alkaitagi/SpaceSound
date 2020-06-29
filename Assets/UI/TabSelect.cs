using System.Linq;
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

    private bool canvasVisible;

    private void Start()
    {
        children = GetComponentsInChildren<Selectable>();
        current = children.FirstOrDefault();
        if (!IsBlocked)
            current?.Select();
    }

    private void Update()
    {
        if (IsBlocked)
            return;

        try
        {
            current =
                EventSystem.current?.currentSelectedGameObject?.GetComponent<Selectable>()
                ?? this.current
                ?? children.FirstOrDefault();
        }
        catch
        {
            current = null;
        }

        if (!current)
            return;
        current.Select();

        if (!Keyboard.current.tabKey.wasPressedThisFrame)
            return;
        var next = Keyboard.current.leftShiftKey.isPressed
            ? current.FindSelectableOnUp()
            : current.FindSelectableOnDown();

        if (next && children.Contains(next))
        {
            next.Select();
            current = next;
        }
        else
            current.Select();
    }
}
