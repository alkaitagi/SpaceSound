using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Engine : MonoBehaviour
{
    public enum EngineType { Straight, Torque }
    [SerializeField]
    private EngineType type;

    [Space(10)]
    [SerializeField]
    private bool isOn;
    public bool IsOn
    {
        get => isOn;
        set
        {
            isOn = value;

            if (effect)
            {
                var emission = effect.emission;
                emission.enabled = IsOn;
            }
            if (light)
                light.enabled = IsOn;
        }
    }
    [SerializeField]
    private float speed;
    public float Speed { get => speed; set => speed = value; }

    [Space(10)]
    [SerializeField]
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private new Light2D light;

    private void Awake() => IsOn = IsOn;

    public void Update()
    {
        if (IsOn)
            switch (type)
            {
                case EngineType.Straight:
                    {
                        rigidbody.AddForce(speed * transform.up);
                        break;
                    }
                case EngineType.Torque:
                    {
                        rigidbody.AddTorque(speed);
                        break;
                    }
            }
    }
}
