using UnityEngine;

public class Door : MonoBehaviour
{
    private int keys;
    public int Keys
    {
        get => keys;
        set
        {
            keys = value;
            if (Keys <= 0)
                Open();
        }
    }

    [SerializeField]
    private ParticleSystem effect;

    public void Open() => effect.Play(true);
}