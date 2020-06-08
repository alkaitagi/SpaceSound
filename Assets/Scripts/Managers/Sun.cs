using System.Linq;
using System.Collections.Generic;

using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private List<Gate> gates;
    [SerializeField]
    private List<GameObject> rewards;
    [SerializeField]
    private Gate end;

    private void Awake()
    {
        var last = RegionManager.Completed.LastOrDefault();

        for (int i = 0; i < gates.Count; i++)
        {
            gates[i].Keys = 1;
            if (RegionManager.Completed.Contains(gates[i].name))
            {
                rewards[i].SetActive(true);
                gates[i].Lock();
                if (last == gates[i].name)
                    Player.Main.transform.position = gates[i].transform.position;
            }
            else
                rewards[i].SetActive(false);
        }

        var vacant = gates.Where(g => !g.IsLocked);
        if (vacant.Any())
        {
            end.Keys = 1;
            vacant.ElementAt(Random.Range(0, vacant.Count())).Keys = 0;
        }
    }
}
