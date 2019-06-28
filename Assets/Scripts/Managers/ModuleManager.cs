using UnityEngine;

[CreateAssetMenu]
public class ModuleManager : ScriptableObject
{
    public bool HasLight { get; set; }
    public bool HasThruster { get; set; }
    public bool HasCannon { get; set; }

    public static ModuleManager Main { get; private set; }

    public void Awake() => Main = this;

    public void ResetModules()
    {
        HasLight = false;
        HasThruster = false;
        HasCannon = false;
    }
}
