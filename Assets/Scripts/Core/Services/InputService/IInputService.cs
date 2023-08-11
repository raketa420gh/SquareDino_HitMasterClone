using UnityEngine;

public interface IInputService
{
    Vector2 AxisMove { get; }
    Vector2 AxisLook { get; }
    bool IsJump { get; }
    bool IsLunge { get; }
}
