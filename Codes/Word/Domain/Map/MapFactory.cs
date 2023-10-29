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
        setMountain(map);
        return map;
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