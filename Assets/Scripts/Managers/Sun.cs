using System.Linq;
using System.Collections.Generic;

using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private List<Gate> gates;
    [SerializeField]
    private List<GameObject> rewards;

    [Space(10)]
    [SerializeField]
    private Gate end;

    private void Awake()
    {
        for (int i = 0; i < gates.Count; i++)
            if (RegionManager.Completed.Contains(gates[i].name))
            {
                rewards[i].SetActive(true);
                gates[i].Lock();
                Player.Main.transform.position = gates[i].transform.position;
            }
            else
            {
                gates[i].Keys = 1;
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
