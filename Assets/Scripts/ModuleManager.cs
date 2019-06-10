using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    public static bool hasLight;
    public bool HasLight { get => hasLight; set => hasLight = value; }

    public static bool hasThruster;
    public bool HasThruster { get => hasThruster; set => hasThruster = value; }

    public static bool hasCannon;
    public bool HasCannon { get => hasCannon; set => hasCannon = value; }

    public void ResetModules()
    {
        HasLight = false;
        HasThruster = false;
        HasCannon = false;
    }

    private void Awake() => ResetModules();
}
