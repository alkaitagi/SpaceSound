using System.Linq;
using UnityEngine;

namespace Sungazer.DangerTracker
{
    public class OrbitsDangerTracker : BaseDangerTracker
    {
        [SerializeField]
        private float distance;

        private Transform[] comets;

        private void Start() =>
            comets = FindObjectsOfType<Damage>()
                .Select(d => d.transform)
                .ToArray();

        private void FixedUpdate()
        {
            var danger = 0f;
            var delta = 1f / comets.Length;

            foreach (var comet in comets)
            {
                var offset = comet.position - Player.Position;
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
