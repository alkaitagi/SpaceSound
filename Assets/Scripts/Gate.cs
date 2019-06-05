using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gate : MonoBehaviour
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


    public void Open()
    {
        GetComponent<Animator>().SetTrigger("Open");
        Camera.main.GetComponent<Animator>().SetTrigger("Warp");
    }
}