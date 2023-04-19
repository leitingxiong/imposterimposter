using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightContext : MonoBehaviour
{
    FightMissionEntity missionEntity;
    public FightMissionEntity MissionEntity => missionEntity;
    FightMissionRepo missionRepo;
    public FightMissionRepo MissionRepo => missionRepo;
    public FightContext()
    {
        this.missionEntity = new FightMissionEntity();
        this.missionRepo = new FightMissionRepo();
    }
}
