using UnityEngine;

public class StandaloneInputService : InputService
{
    public override Vector2 AxisMove => GetInputAxisMove();
    public override Vector2 AxisLook => GetInputAxisLook();
    public override bool IsJump => GetJump();
    public override bool IsLunge => GetLunge();
}