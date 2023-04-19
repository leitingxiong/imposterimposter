using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMissionRepo
{
    Dictionary<int, FightMissionEntity> all;
    FightMissionEntity fightEntity;
    public FightMissionRepo()
    {
        this.all = new Dictionary<int, FightMissionEntity>();
    }

    public void Add(FightMissionEntity entity)
    {
        this.all.Add(entity.EntityID, entity);
    }

    public bool TryGet(int entityID, out FightMissionEntity entity)
    {
        return all.TryGetValue(entityID, out entity);
    }

    public FightMissionEntity GetFirst()
    {
        return fightEntity;
    }

    public void Remove(int entityID)
    {
        all.Remove(entityID);
    }

    public void Clear()
    {
        all.Clear();
    }
}
