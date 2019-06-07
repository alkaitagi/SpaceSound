using UnityEngine;

public class EventListener : MonoBehaviour
{
    [SerializeField]
    private VoidEvent onAwake;
    [SerializeField]
    private VoidEvent onDestroy;

    private void Awake() => onAwake.Invoke();
    private void OnDestroy() => onDestroy.Invoke();
}
