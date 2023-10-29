using System;
using Godot;

namespace ShengChao.Codes.Word.Domain.Map.MapBlock;

public class MapBlock
{
    protected TileSetSource _tileSetSource;

    public bool isCollide { set; get; }

    public bool isCover { set; get; }

    public bool isMonsterFarming { set; get; } = true;
    public int sourseId { get; set; }

    public Vector2 localPostion { set; get; }

    public MapBlock(TileSetSource tileSetSource)
    {
        _tileSetSource = tileSetSource;
    }

    public virtual Vector2I createRandomAtlas()
    {
        return new Vector2I(new Random().Next(0, _tileSetSource.GetTilesCount()), 0);
    }
}