using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial class WoodMonster : BaseMonster
{
    public WoodMonster()
    {
        base._Ready();
        GetNode<Label>("Label").Text = "木";
        GetNode<Label>("Label").LabelSettings.FontColor = Color.Color8(0, 0, 0, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate = Color.Color8(255, 255, 255, 255);
    }
}