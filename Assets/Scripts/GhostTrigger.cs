using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    [SerializeField]
    private float radius;

    private static Collider2D[] ghosts = new Collider2D[50];

    public void Trigger()
    {
        var minReactionDelay = float.MaxValue;
        var count = Physics2D.OverlapCircleNonAlloc(transform.position,
                                                    radius,
                                                    ghosts,
                                                    LayerMask.GetMask("Unit"));
        for (; --count > -1;)
            if (ghosts[count].GetComponent<Ghost>() is Ghost ghost)
            {
                if (ghost.ReactionDelay < minReactionDelay)
                    minReactionDelay = ghost.ReactionDelay;

                ghost.StopAllCoroutines();
                ghost.StartCoroutine(ghost.Trigger(transform.position));
            }

        // pause music for "minReactionDelay"
    }
}
