using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private ParticleSystem[] effects;
    [SerializeField]
    private ParticleSystem[] connections;

    public void CountArea(GameObject area)
    {
        effects[--score].Play();
        connections[score].Stop();
        Destroy(area);

        if (score <= 0) { }
    }
}
