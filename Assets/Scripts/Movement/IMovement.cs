using UnityEngine;

public interface IMovement
{
    void MoveTo(Vector3 destination);
    void Stop();
}