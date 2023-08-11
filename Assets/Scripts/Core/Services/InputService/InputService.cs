using UnityEngine;

public abstract class InputService : IInputService
{
    protected const string HorizontalMove = "Horizontal";
    protected const string VerticalMove = "Vertical";
    protected const string HorizontalLook = "Mouse X";
    protected const string VerticalLook = "Mouse Y";
    protected const string Jump = "Jump";
    
    public abstract Vector2 AxisMove { get; }
    public abstract Vector2 AxisLook { get; }
    public abstract bool IsJump { get; }
    public abstract bool IsLunge { get; }

    protected static Vector2 GetInputAxisMove() =>
        new Vector2(Input.GetAxis(HorizontalMove), Input.GetAxis(VerticalMove));

    protected static Vector2 GetInputAxisLook() =>
        new Vector2(Input.GetAxis(HorizontalLook), Input.GetAxis(VerticalLook));

    protected static bool GetJump() => Input.GetButtonDown(Jump);

    protected static bool GetLunge() => Input.GetMouseButtonDown(1);
}