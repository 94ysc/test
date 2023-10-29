using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Godot;
using Godot.NativeInterop;

namespace ShengChao.Codes.Word.Domain.Map.MapBlock;

public class GrassMapBlock : MapBlock
{
    public GrassMapBlock(TileSetSource tileSetSource) : base(tileSetSource)
    {
        isCover = true;
        isCollide = false;
        sourseId = 2;
        setTiles();
    }

    private void setTiles()
    {
        titles[100] = 0;
        titles[90] = 1;
        titles[80] = 2;
        titles[79] = 3;
        titles[77] = 4;
        titles[75] = 5;
        titles[72] = 6;
        titles[67] = 7;
        titles[60] = 8;
    }

    private SortedDictionary<int, int> titles = new();

    public override Vector2I createRandomAtlas()
    {
        var count = _tileSetSource.GetTilesCount();
        var i = new Random().Next(0, 100);
        foreach (var keyValuePair in titles)
        {
            if (keyValuePair.Key > i)
            {
                return new Vector2I(keyValuePair.Value, 0);
            }
        }
        return new Vector2I(0, 0);
    }
}