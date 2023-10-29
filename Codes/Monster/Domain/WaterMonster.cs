using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial class WaterMonster:BaseMonster
{
    public WaterMonster()
    {
        base._Ready();
        GetNode<Label>("Label").Text =  "水";
        GetNode<Label>("Label").LabelSettings.FontColor = Color.Color8(255, 255, 255, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate = Color.Color8(0, 0, 0, 255);
    }
}