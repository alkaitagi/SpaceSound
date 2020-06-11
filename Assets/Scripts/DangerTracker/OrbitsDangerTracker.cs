using UnityEngine;

namespace Sungazer.DangerTracker
{
    public class OrbitsDangerTracker : BaseDangerTracker
    {
        [SerializeField]
        private float distance;

        private Comet[] comets;

        private void Start() =>
            comets = FindObjectsOfType<Comet>();

        private void FixedUpdate()
        {
            var danger = 0f;
            var delta = 1 / comets.Length;

            foreach (var comet in comets)
            {
                var offset = comet.transform.position - Player.Position;
                var distance = offset.magnitude;
                var direction = offset.normalized;
                var dot = Vector2.Dot(comet.transform.up, direction);

                if (distance <= this.distance && dot > 0)
                    danger += delta * dot * distance / this.distance;
            }

            Danger = danger;
        }
    }
}
