using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class KeyDisplay : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int keyCount;
    private new Animation animation;

    private void Awake() => animation = GetComponent<Animation>();

    private void Start() => keyCount = FindObjectsOfType(typeof(Key)).Length;

    private void Update()
    {
        var newText = (keyCount - StatsManager.Main.Keys.Count).ToString();
        if (newText != text.text)
            animation.Play();
        text.text = newText;
    }
}
