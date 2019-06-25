using System.Collections.Generic;

using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> rewards;
    [SerializeField]
    private List<Gate> gates;
    [SerializeField]
    private List<GameObject> regions;

    private int current;

    private void Awake()
    {
        for (int i = 0; i < gates.Count; i++)
        {
            rewards[i].SetActive(false);
            regions[i].SetActive(false);
            gates[i].Keys = 1;
        }
        NextGate();
    }

    public void OpenRegion() => regions[current].SetActive(true);

    public void LockRegion()
    {
        rewards[current].SetActive(true);
        regions[current].SetActive(false);

        rewards.RemoveAt(current);
        gates.RemoveAt(current);
        regions.RemoveAt(current);

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
