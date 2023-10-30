using Godot;
using ShengChao.Codes.Monster.Domain;

namespace ShengChao.Codes.Monster.ACL.Adapter.Repository;

public interface IMonsterRepository
{
    void Save(BaseMonster monster);

}