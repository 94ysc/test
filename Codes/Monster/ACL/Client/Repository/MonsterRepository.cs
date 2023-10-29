using System.Collections.Generic;
using System.Linq;
using ShengChao.Codes.Monster.ACL.Adapter.Repository;
using ShengChao.Codes.Monster.Domain;

namespace ShengChao.Codes.Monster.ACL.Client.Repository;

public class MonsterRepository : IMonsterRepository
{
    public static Queue<BaseMonster> _baseMonsters = new();

    public void save(BaseMonster monster)
    {
        _baseMonsters.Enqueue(monster);
    }
}