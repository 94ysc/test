using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial class GoldMonster : BaseMonster
{
    public GoldMonster()
    {
        base._Ready();
        AddToGroup("goldMonster");
        GetNode<Label>("Label").Text = "金";
        GetNode<Label>("Label").LabelSettings.FontColor =Color.Color8(30, 19, 29, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate = Color.Color8(248, 244, 237, 255);
        Phase = "Gold";
        TargetPhase = "Soil";
        HostilePhase.Add( "Fire");
        HostilePhase.Add("Water");
    }
}