using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial  class FireMonster:BaseMonster
{
    
    public FireMonster()
    {
        base._Ready();
        GetNode<Label>("Label").Text = "火";
        GetNode<Label>("Label").LabelSettings.FontColor =Color.Color8(248, 244, 237, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate =Color.Color8(252, 99, 21, 255);
    }
}