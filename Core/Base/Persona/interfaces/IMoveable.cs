namespace Test.Player.domain.interfaces;

using Godot;

public interface IMoveable
{
    bool IsFacingRight { set; get; }

    void Move(Vector2 velocity);

    void CheckForLeftOrRightFacing(Vector2 velocity);
}