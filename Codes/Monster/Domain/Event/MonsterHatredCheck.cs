using Godot;

namespace ShengChao.Codes.Domain.checks;

/// <summary>
/// 怪物仇恨检测
/// </summary>
public interface MonsterHatredCheck
{
    void HateAttracts(Area2D area2D);
}