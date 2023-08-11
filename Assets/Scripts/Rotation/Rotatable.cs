using UnityEngine;

public class Rotatable : MonoBehaviour, IRotatable
{
    public void Rotate(Vector3 axis, float speed)
    {
        transform.Rotate(axis * (speed * Time.deltaTime));
    }
    
    public void LookAtOnlyY(Vector3 targetWorldPosition)
    {
        var target = new Vector3(targetWorldPosition.x, transform.position.y, targetWorldPosition.z);
        transform.LookAt(target);
    }
}