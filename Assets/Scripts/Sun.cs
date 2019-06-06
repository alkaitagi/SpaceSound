using System.Collections.Generic;

using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> rewards;
    [SerializeField]
    private List<Gate> gates;

    private int current;

    private void Awake()
    {
        foreach (var reward in rewards)
            reward.SetActive(false);

        foreach (var gate in gates)
            gate.Keys = 1;

        NextGate();
    }

    public void CountArea(GameObject area)
    {
        rewards[current].SetActive(true);
        rewards.RemoveAt(current);
        gates.RemoveAt(current);

        Destroy(area);
        if (!NextGate()) { }
    }

    private bool NextGate()
    {
        if (gates.Count > 0)
        {
            current = Random.Range(0, gates.Count);
            gates[current].Keys = 0;
            return true;
        }
        return false;
    }
}
