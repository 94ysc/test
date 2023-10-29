using System;
using System.Threading;
using Godot;
using ShengChao.Codes.Core.Base;
using ShengChao.Codes.Word.ACL.Adapter.Repository;
using ShengChao.Codes.Word.ACL.Client.Repository;

namespace ShengChao.Codes.Word.Domain.Map;

public class MapFactory
{
    private IMapRepository _mapRepository = new MapRepository();


    public Map createRandomMap()
    {
        Map map = new Map(_mapRepository.GetTileSet());
        setTopography(map);
        // setMountain(map);
        // setNotMountain(map);
        setNotMonsterFarming(map);
        return map;
    }

    private void setNotMonsterFarming(Map map)
    {
        Rect2 rect2 = new Rect2(new Vector2(map.verCellNum / 2 - 8, map.horCellNum / 2 + 4), new Vector2(16, 8));
        foreach (var keyValuePair in map.mapBlocks)
        {
            if (rect2.HasPoint(keyValuePair.Key))
            {
                keyValuePair.Value.isMonsterFarming = false;
            }
        }
    }

    private void setNotMountain(Map map)
    {
        Rect2 rect2 = new Rect2(new Vector2(map.verCellNum / 2 - 2, map.horCellNum / 2 + 2), new Vector2(4, 4));
        foreach (var keyValuePair in map.mapBlocks)
        {
            if (rect2.HasPoint(keyValuePair.Key))
            {
                var graee = _mapRepository.create(MapRepository.MapBlockType.Grass);
                map.addMapBlock(new Vector2I(map.horCellNum / 2, map.verCellNum / 2), graee);
            }
        }
    }

    public void setTopography(Map map)
    {
        foreach (var vector2I in map.traverse())
        {
            var noiseValue =
                new NoiseRandom(map.cellSize, map._width, map._height).getIslandNoise(vector2I.X, vector2I.Y);
            MapBlock.MapBlock mapBlock = _mapRepository.createTerrainRandom(noiseValue);
            map.addMapBlock(vector2I, mapBlock);
        }
    }

    public void setMountain(Map map)
    {
        foreach (var keyValuePair in map.mapBlocks)
        {
            if (keyValuePair.Value.isCover)
            {
                if (new Random().Next(1, 100) < 10)
                {
                    map.addMapBlock(keyValuePair.Key, _mapRepository.create(MapRepository.MapBlockType.Mountain));
                }
            }
        }
    }
}