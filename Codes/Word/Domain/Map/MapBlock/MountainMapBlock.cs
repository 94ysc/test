using Godot;

namespace ShengChao.Codes.Word.Domain.Map.MapBlock;

public class MountainMapBlock : MapBlock
{
    public MountainMapBlock(TileSetSource tileSetSource) : base(tileSetSource)
    {
        isCover = true;
        isCollide = true;
        sourseId = 0;
    }
}