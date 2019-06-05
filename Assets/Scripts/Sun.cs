using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private ParticleSystem[] effects;

    public void CountArea(GameObject area)
    {
        effects[--score].Play();
        Destroy(area);
    }
}
