using System.Linq;
using UnityEngine;

namespace Sungazer.DangerTracker
{
    public class InvasionDangerTracker : BaseDangerTracker
    {
        [SerializeField]
        private float distance;

        private Transform[] creeps;

        private void Start() =>
            creeps = FindObjectsOfType<Creep>()
                .Select(c => c.transform)
                .ToArray();

        private void FixedUpdate()
        {
            var danger = 0f;
            var delta = 1f / creeps.Where(c => c).Count();

            foreach (var creep in creeps.Where(c => c))
            {
                var offset = creep.position - Player.Position;
                var distance = offset.magnitude;
                var direction = offset.normalized;
                // var dot = Vector2.Dot(creep.up, direction);
                var dot = 1;

                if (distance <= this.distance && dot > 0)
                    danger += delta * dot * distance / this.distance;
            }

            Danger = danger;
        }
    }
}
