using UnityEngine;

namespace Sungazer.DangerTracker
{
    public abstract class BaseDangerTracker : MonoBehaviour
    {
        public static float Danger { get; protected set; }

        protected static void Reset()
        {
            Danger = 0;
        }

        private void OnDestroy() =>
            Reset();
    }
}
