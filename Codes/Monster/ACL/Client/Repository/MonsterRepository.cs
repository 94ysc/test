using System.Collections.Generic;
using System.Linq;
using Godot;
using ShengChao.Codes.Monster.ACL.Adapter.Repository;
using ShengChao.Codes.Monster.Domain;

namespace ShengChao.Codes.Monster.ACL.Client.Repository;

public class MonsterRepository : IMonsterRepository
{
    public static readonly List<BaseMonster> BaseMonsters = new();


    public void Save(BaseMonster monster)
    {
        BaseMonsters.Add(monster);
    }

}