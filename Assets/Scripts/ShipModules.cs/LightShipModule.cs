using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Sungazer.ShipModules
{
    public class LightShipModule : BaseShipModule
    {
        [SerializeField]
        private bool active;
        public bool Active
        {
            get => active;
            set
            {
                active = value;
                onActiveChange.Invoke(Active);
            }
        }
        [SerializeField]
        private BoolEvent onActiveChange;

        [Space(10)]
        [SerializeField]
        private float activeIntensity;
        [SerializeField]
        private float clapmedIntensity;
        [SerializeField]
        private float inactiveIntensity;

        [Space(10)]
        [SerializeField]
        private float fadeSpeed;
        [SerializeField]
        private bool clamped;
        public bool Clamped
        {
            get => clamped;
            set
            {
                clamped = value;

                foreach (var l in lights)
                    if (l.GetComponent<ParticleSystem>() is ParticleSystem p)
                        p.Emission(Clamped);
            }
        }

        [SerializeField]
        private Light2D[] lights;

        private void Start()
        {
            Clamped = Clamped;

            foreach (var l in lights)
                l.intensity = TargetIntensity;
        }

        private void Update()
        {
            foreach (var l in lights)
                l.intensity = Mathf.MoveTowards(l.intensity,
                                                TargetIntensity,
                                                fadeSpeed * Time.deltaTime);
        }

        public override void Use() =>
            ToggleActive();

        public void ToggleActive() =>
            Active = !Active;

        public void ToggleClamped() =>
            Clamped = !Clamped;

        private float TargetIntensity =>
            Active
                ? (Clamped ? clapmedIntensity : activeIntensity)
                : 0;
    }
}
