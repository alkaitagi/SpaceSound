using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField, Range(1, 5)]
    private int updateRate;
    [SerializeField]
    private FloatEvent onUpdate;

    private int frames;
    private float deltaTime;

    void Update()
    {
        frames++;
        deltaTime += Time.unscaledDeltaTime;
        if (deltaTime > 1f / updateRate)
        {
            onUpdate.Invoke(frames / deltaTime);
            frames = 0;
            deltaTime -= 1f / updateRate;
        }
    }
}
