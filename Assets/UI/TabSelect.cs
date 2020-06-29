using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TabSelect : MonoBehaviour
{
    private Selectable current;

    private void Start() =>
        (current = GetComponentInChildren<Selectable>())
            ?.Select();

    private void Update()
    {
        if (!Keyboard.current.tabKey.wasPressedThisFrame)
            return;

        var current = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>();
        if (!current && !(current = this.current))
            return;

        var next = Keyboard.current.leftShiftKey.isPressed
            ? current.FindSelectableOnUp()
            : current.FindSelectableOnDown();

        if (next)
        {
            next?.Select();
            this.current = next;
        }
    }
}
