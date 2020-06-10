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
            var count = 0;

            foreach (var comet in comets)
            {
                var offset = comet.transform.position - Player.Position;
                var direction = offset.normalized;
                var distance = direction.magnitude;
                var dot = Vector2.Dot(comet.transform.up, direction);
                if (distance <= this.distance && dot >= .5f)
                    count++;
            }

            Danger = count / comets.Length;
        }
    }
}
