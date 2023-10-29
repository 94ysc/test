using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial  class FireMonster:BaseMonster
{
    
    public FireMonster()
    {
        base._Ready();
        GetNode<Label>("Label").Text = "火";
        GetNode<Label>("Label").LabelSettings.FontColor = Color.Color8(0, 0, 0, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate =Color.Color8(229, 96, 39, 255);
    }
}