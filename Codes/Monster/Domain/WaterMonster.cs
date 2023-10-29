using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial class WaterMonster:BaseMonster
{
    public WaterMonster()
    {
        base._Ready();
        GetNode<Label>("Label").Text =  "水";
        GetNode<Label>("Label").LabelSettings.FontColor = Color.Color8(248, 244, 237, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate = Color.Color8(30, 19, 29, 255);
    }
}