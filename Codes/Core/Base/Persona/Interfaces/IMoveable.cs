namespace ShengChao.Codes.persona;

using Godot;

public interface IMoveable
{
    bool IsFacingRight { set; get; }

    void Move(Vector2 velocity,double delta);

    void CheckForLeftOrRightFacing(Vector2 velocity);
}