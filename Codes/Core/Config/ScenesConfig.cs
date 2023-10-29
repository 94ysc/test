using System;
using System.Collections.Generic;
using Godot;

namespace ShengChao.Codes.Core.Config;

public class ScenesConfig
{
    public enum Scennes
    {
        Word,
        Player,
        Monster,
        BaseCamp
    }

    private static Dictionary<Scennes, String> scenneDictionary;

    static ScenesConfig()
    {
        scenneDictionary = new Dictionary<Scennes, string>();
        scenneDictionary.Add(Scennes.Word, "res://Scenes/word.tscn");
        scenneDictionary.Add(Scennes.Player, "res://Scenes/player.tscn");
        scenneDictionary.Add(Scennes.Monster, "res://Scenes/monster.tscn");
        scenneDictionary.Add(Scennes.BaseCamp, "res://Scenes/baseCamp.tscn");
    }

    public static PackedScene create(Scennes scennes)
    {
        return GD.Load<PackedScene>(scenneDictionary[scennes]);
    }
}