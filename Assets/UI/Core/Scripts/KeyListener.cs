using UnityEngine;

public class KeyListener : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private VoidEvent onPress;
    [SerializeField]
    private VoidEvent onRaise;
    [SerializeField]
    private BoolEvent onHold;

    private void Update()
    {
        if (!UIUtility.IsInput)
            if (Input.GetKeyDown(key))
            {
                Press();
                Hold(true);
            }
            else if (Input.GetKeyUp(key))
            {
                Raise();
                Hold(false);
            }
    }

    public void Press() => onPress.Invoke();
    public void Raise() => onRaise.Invoke();
    public void Hold(bool value) => onHold.Invoke(value);
}
