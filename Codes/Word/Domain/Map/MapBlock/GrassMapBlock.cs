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
    }
}