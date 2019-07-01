using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int keyCount;

    private void Start() => keyCount = FindObjectsOfType(typeof(Key)).Length;

    private void Update() => text.text = (keyCount - StatsManager.Main.Keys.Count).ToString();
}
