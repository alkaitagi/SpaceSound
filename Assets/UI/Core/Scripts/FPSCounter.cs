using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private FloatEvent onCount;

    private int frames;
    private float timer;
    private const float threshold = .25f;

    void Update()
    {
        frames++;
        timer += Time.unscaledDeltaTime;

        if (timer > threshold)
        {
            onCount.Invoke((int)(frames / timer));
            frames = 0;
            timer -= threshold;
        }
    }
}
