using UnityEngine;

namespace Sungazer.DangerTracker
{
    public class NebulaDangerTracker : BaseDangerTracker
    {
        [SerializeField]
        private float distance;

        private Ghost[] ghosts;

        private void Start() =>
            ghosts = FindObjectsOfType<Ghost>();

        private void FixedUpdate()
        {
            var danger = 0f;
            var delta = 1 / ghosts.Length;

            foreach (var ghost in ghosts)
            {
                var offset = ghost.transform.position - Player.Position;
                var distance = offset.magnitude;
                var direction = offset.normalized;

                if (ghost.IsCharging && distance <= this.distance)
                    danger += delta * ghost.ChargeLevel * distance / this.distance;
            }

            Danger = danger;
        }
    }
}
