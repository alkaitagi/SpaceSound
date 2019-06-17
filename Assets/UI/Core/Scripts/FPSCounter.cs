using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;

    private Text text;

    private int frames;
    private float timer;
    private const float threshold = .25f;

    private void Awake() => text = GetComponent<Text>();

    void Update()
    {
        frames++;
        timer += Time.unscaledDeltaTime;

        if (timer > threshold)
        {
            text.text = ((int)(frames / timer)).ToString();
            frames = 0;
            timer -= threshold;
        }

        if (Input.GetKeyDown(key))
            text.enabled = !text.enabled;
    }
}
