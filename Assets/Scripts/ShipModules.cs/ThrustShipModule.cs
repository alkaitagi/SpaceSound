using UnityEngine;

namespace Sungazer.ShipModules
{
    public class ThrustShipModule : BaseShipModule
    {
        [SerializeField]
        private float force;
        [SerializeField]
        private float cooldown;

        [Space(10)]
        [SerializeField]
        private GameObject effect;

        private new Rigidbody2D rigidbody;

        private void Awake() =>
            rigidbody = GetComponentInParent<Rigidbody2D>();

        private bool isReady = true;
        private void Ready() =>
            isReady = true;

        public override void Use() =>
            Burst();

        public void Burst()
        {
            if (!isReady)
                return;
                
            isReady = false;
            Invoke("Ready", cooldown);

            rigidbody.AddForce(force * transform.up, ForceMode2D.Impulse);
            if (effect)
                Instantiate(effect, transform.position, transform.rotation);
        }
    }
}
