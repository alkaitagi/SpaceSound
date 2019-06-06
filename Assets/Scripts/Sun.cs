using System.Collections.Generic;

using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> effects;
    [SerializeField]
    private List<Gate> gates;

    private int current;

    private void Awake()
    {
        foreach (var gate in gates)
            gate.Keys = 1;
        NextGate();
    }

    public void CountArea(GameObject area)
    {
        effects[current].Play();
        effects.RemoveAt(current);
        gates.RemoveAt(current);

        Destroy(area);
        if (!NextGate()) { }
    }

    private bool NextGate()
    {
        if (gates.Count > 0)
        {
            current = Random.Range(0, gates.Count);
            print(current);
            gates[current].Keys = 0;
            return true;
        }
        return false;
    }
}
