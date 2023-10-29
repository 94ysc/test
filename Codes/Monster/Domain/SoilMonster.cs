using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial class SoilMonster : BaseMonster
{
    public SoilMonster()
    {
        base._Ready();
        GetNode<Label>("Label").Text =  "土";
        GetNode<Label>("Label").LabelSettings.FontColor = Color.Color8(0, 0, 0, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate =Color.Color8(238, 211, 94, 255);
    }
}