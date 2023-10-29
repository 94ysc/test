using Godot;

namespace ShengChao.Codes.Word.Domain.Map.MapBlock;

public class WaterMapBlock : MapBlock
{
    public WaterMapBlock(TileSetSource tileSetSource) : base(tileSetSource)
    {
        isCover = false;
        isCollide = true;
        sourseId = 1;
    }
}