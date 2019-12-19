using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    [SerializeField]
    private float radius;

    private static Collider2D[] ghosts = new Collider2D[50];

    public void Trigger()
    {
        var count = Physics2D.OverlapCircleNonAlloc(transform.position,
                                                    radius,
                                                    ghosts,
                                                    LayerMask.GetMask("Unit"));
        for (; --count > -1;)
            if (ghosts[count].GetComponent<Ghost>() is Ghost ghost)
                ghost.Trigger(transform.position);
    }
}
