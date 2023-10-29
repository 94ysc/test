using System;
using System.Collections;
using System.Collections.Generic;
using Godot;
using ShengChao.Codes.Word.ACL.Client.Repository;
using ShengChao.Codes.Word.Domain.Map.MapBlock;

namespace ShengChao.Codes.Word.ACL.Adapter.Repository;

public class MapRepository : IMapRepository
{
    public enum MapBlockType
    {
        Mountain = 0,
        Water = 1,
        Grass = 2
    }

    public static Dictionary<MapBlockType, Func<TileSetSource, MapBlock>> _mapBlocks = new();

    static MapRepository()
    {
        _mapBlocks[MapBlockType.Mountain] = (set =>
        {
            return new MountainMapBlock(set);
        });
        _mapBlocks[MapBlockType.Water] = (set =>
        {
            return new WaterMapBlock(set);
        });
        _mapBlocks[MapBlockType.Grass] = (set =>
        {
            return new GrassMapBlock(set);
        });
    }

    public MapBlock create(MapBlockType mapBlockType)
    {
        var resource = GD.Load<TileSet>("res://Resrouse/word.tres");
        return _mapBlocks[mapBlockType](resource.GetSource((int)mapBlockType));
    }

    public MapBlock createTerrainRandom(double curNoiseValue)
    {
        if (curNoiseValue > 0 && curNoiseValue < 0.5)
        {
            return create(MapBlockType.Water);
        }

        return create(MapBlockType.Grass);
    }

    public TileSet GetTileSet()
    {
        return GD.Load<TileSet>("res://Resrouse/word.tres");
    }
}