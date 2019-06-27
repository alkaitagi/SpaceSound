using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int frames;
    private float timer;
    private const float threshold = .25f;

    private void Update()
    {
        frames++;
        timer += Time.unscaledDeltaTime;

        if (timer > threshold)
        {
            text.text = ((int)(frames / timer)).ToString();
            frames = 0;
            timer -= threshold;
        }
    }
}
