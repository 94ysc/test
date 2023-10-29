using System;
using System.Collections.Generic;
using Godot;
using ShengChao.Codes.Core.Config;
using ShengChao.Codes.Monster.ACL.Adapter.Repository;
using ShengChao.Codes.Monster.ACL.Client.Repository;

namespace ShengChao.Codes.Monster.Domain.Factory;

public class MonsterFactory
{
    public enum MonsterType
    {
        Fire,
        Gold,
        Soil,
        Water,
        Wood
    }

    private static Dictionary<MonsterType, Func<BaseMonster>> _dictionary = new();

    private IMonsterRepository _monsterRepository = new MonsterRepository();

    static MonsterFactory()
    {
        _dictionary[MonsterType.Gold] = (() =>
        {
            var monsterScene = ScenesConfig.create(ScenesConfig.Scennes.Monster);
            var monsterInstantiate = monsterScene.Instantiate();
            ulong monsterInstanceId = monsterInstantiate.GetInstanceId();
            Resource script = GD.Load("res://Codes/Monster/Domain/GoldMonster.cs");
            monsterInstantiate.SetScript(script);
            monsterInstantiate = GodotObject.InstanceFromId(monsterInstanceId) as GoldMonster;
            return (BaseMonster)monsterInstantiate;
        });
        _dictionary[MonsterType.Wood] = (() =>
        {
            var monsterScene = ScenesConfig.create(ScenesConfig.Scennes.Monster);
            var monsterInstantiate = monsterScene.Instantiate();
            ulong monsterInstanceId = monsterInstantiate.GetInstanceId();
            Resource script = GD.Load("res://Codes/Monster/Domain/WoodMonster.cs");
            monsterInstantiate.SetScript(script);
            monsterInstantiate = GodotObject.InstanceFromId(monsterInstanceId) as WoodMonster;
            return (BaseMonster)monsterInstantiate;
        });
        _dictionary[MonsterType.Water] = (() =>
        {
            var monsterScene = ScenesConfig.create(ScenesConfig.Scennes.Monster);
            var monsterInstantiate = monsterScene.Instantiate();
            ulong monsterInstanceId = monsterInstantiate.GetInstanceId();
            Resource script = GD.Load("res://Codes/Monster/Domain/WaterMonster.cs");
            monsterInstantiate.SetScript(script);
            monsterInstantiate = GodotObject.InstanceFromId(monsterInstanceId) as WaterMonster;
            return (BaseMonster)monsterInstantiate;
        });
        _dictionary[MonsterType.Fire] = (() =>
        {
            var monsterScene = ScenesConfig.create(ScenesConfig.Scennes.Monster);
            var monsterInstantiate = monsterScene.Instantiate();
            ulong monsterInstanceId = monsterInstantiate.GetInstanceId();
            Resource script = GD.Load("res://Codes/Monster/Domain/FireMonster.cs");
            monsterInstantiate.SetScript(script);
            monsterInstantiate = GodotObject.InstanceFromId(monsterInstanceId) as FireMonster;
            return (BaseMonster)monsterInstantiate;
        });
        _dictionary[MonsterType.Soil] = (() =>
        {
            var monsterScene = ScenesConfig.create(ScenesConfig.Scennes.Monster);
            var monsterInstantiate = monsterScene.Instantiate();
            ulong monsterInstanceId = monsterInstantiate.GetInstanceId();
            Resource script = GD.Load("res://Codes/Monster/Domain/SoilMonster.cs");
            monsterInstantiate.SetScript(script);
            monsterInstantiate = GodotObject.InstanceFromId(monsterInstanceId) as SoilMonster;
            return (BaseMonster)monsterInstantiate;
        });
    }

    public BaseMonster of(MonsterType monsterType)
    {
        var baseMonster = _dictionary[monsterType].Invoke();
        _monsterRepository.save(baseMonster);
        return baseMonster;
    }
}