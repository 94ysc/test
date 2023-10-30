using Godot;

namespace ShengChao.Codes.Monster.Domain;

public partial class WoodMonster : BaseMonster
{
    public WoodMonster()
    {
        base._Ready();
        AddToGroup("woodMonster");
        GetNode<Label>("Label").Text = "木";
        GetNode<Label>("Label").LabelSettings.FontColor = Color.Color8(248, 244, 237, 255);
        GetNode<Sprite2D>("Sprite2D").Modulate = Color.Color8(44, 150, 120, 255);
        Phase = "Wood";
        TargetPhase = "Water";
        HostilePhase.Add("Gold");
        HostilePhase.Add("Fire");
    }
}