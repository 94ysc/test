using Godot;
using ShengChao.Codes.Word.ACL.Adapter.Repository;
using ShengChao.Codes.Word.Domain.Map.MapBlock;

namespace ShengChao.Codes.Word.ACL.Client.Repository;

public interface IMapRepository
{
    public MapBlock create(MapRepository.MapBlockType mapBlockType);
    MapBlock createTerrainRandom(double curNoiseValue);

    public TileSet GetTileSet();
}