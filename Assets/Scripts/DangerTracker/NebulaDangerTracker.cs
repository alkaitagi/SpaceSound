using System.Linq;

namespace Sungazer.DangerTracker
{
    public class NebulaDangerTracker : BaseDangerTracker
    {
        private Ghost[] ghosts;

        private void Start() =>
            ghosts = FindObjectsOfType<Ghost>();

        private void FixedUpdate() =>
            Danger = ghosts.Count(g => g.IsCharging) / ghosts.Length;
    }
}
