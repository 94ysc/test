using System;
using System.Collections.Generic;
using Godot;

namespace ShengChao.Codes.Word.Domain.Map;

public partial class Map : TileMap
{
    public Vector2 cellSize { set; get; } = new Vector2(120, 140);
    public int horCellNum { set; get; } = 100;
    public int verCellNum { set; get; } = 100;
    public int _width { get; set; }
    public int _height { get; set; }

    public Dictionary<Vector2I, MapBlock.MapBlock> mapBlocks;

    public Map()
    {
        init();
    }

    public Map(TileSet tileSet)
    {
        TileSet = tileSet;
        init();
    }

    public void init()
    {
        _width = (int)(cellSize.X * horCellNum);
        _height = (int)(cellSize.Y * verCellNum);
        mapBlocks = new();
    }

    public override void _Ready()
    {
    }


    public void addTopography(int i, Vector2I vector2I, int sourceId, Vector2I createRandomAtlas)
    {
        SetCell(i, vector2I, sourceId, createRandomAtlas);
    }

    public IEnumerable<Vector2I> traverse()
    {
        for (int y = 0; y < verCellNum; y++)
        {
            for (int x = 0; x < horCellNum; x++)
            {
                yield return new Vector2I(x, y);
            }
        }
    }

    public void addMapBlock(Vector2I vector2I, MapBlock.MapBlock mapBlock)
    {
        if (!mapBlocks.ContainsKey(vector2I) || mapBlocks[vector2I].isCover)
        {
            mapBlocks[vector2I] = mapBlock;
            SetCell(0, vector2I, mapBlock.sourseId, mapBlock.createRandomAtlas());
        }
    }
}