using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    private Text text;

    private void Awake() => text = GetComponent<Text>();

    private void FixedUpdate()
    {
        var keys = FindObjectsOfType(typeof(Key)).Length;
        text.text = keys > 0 ? keys.ToString() : string.Empty;
    }
}
