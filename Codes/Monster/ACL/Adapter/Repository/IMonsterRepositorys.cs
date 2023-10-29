using ShengChao.Codes.Monster.Domain;

namespace ShengChao.Codes.Monster.ACL.Adapter.Repository;

public interface IMonsterRepository
{
    void save(BaseMonster monster);
}