using UnityEngine;

public class WorldPoint : MonoBehaviour
{
    public Vector3 Position => transform.position;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,0.2f);
        Gizmos.color = Color.blue;
    }
}