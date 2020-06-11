using UnityEngine;

namespace Sungazer.DangerTracker
{
    public class InvasionDangerTracker : BaseDangerTracker
    {
        [SerializeField]
        private float distance;

        private Creep[] creeps;

        private void Start() =>
            creeps = FindObjectsOfType<Creep>();

        private void FixedUpdate()
        {
            var danger = 0f;
            var delta = 1 / creeps.Length;

            foreach (var creep in creeps)
            {
                var offset = creep.transform.position - Player.Position;
                var distance = offset.magnitude;
                var direction = offset.normalized;
                var dot = Vector2.Dot(creep.transform.up, direction);

                if (distance <= this.distance && dot > 0)
                    danger += delta * dot * distance / this.distance;
            }

            Danger = danger;
        }
    }
}
