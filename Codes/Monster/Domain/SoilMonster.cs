using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial class SoilMonster : BaseMonster
{
    public SoilMonster()
    {
        base._Ready();
        GetNode<Label>("Label").Text =  "土";
        GetNode<Label>("Label").LabelSettings.FontColor = Color.Color8(30, 19, 29, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate =Color.Color8(252, 195, 7, 255);
    }
}