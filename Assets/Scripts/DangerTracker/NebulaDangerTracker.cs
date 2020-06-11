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
                var dot = Vector2.Dot(ghost.transform.up, direction);

                if (distance <= this.distance && dot > 0)
                    danger += delta * dot * distance / this.distance;
            }

            Danger = danger;
        }
    }
}
