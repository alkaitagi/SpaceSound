using System.Linq;
using UnityEngine;

namespace Sungazer.DangerTracker
{
    public class InvasionDangerTracker : BaseDangerTracker
    {
        [SerializeField]
        private float radius;

        private Creep[] creeps;

        private void Start() =>
            creeps = FindObjectsOfType<Creep>();

        private void FixedUpdate() =>
            Danger =
                creeps
                .Select(c => c.transform.position)
                .Select(p => (p - Player.Position))
                .Count(v => v.sqrMagnitude < radius * radius)
                / creeps.Length;
    }
}
