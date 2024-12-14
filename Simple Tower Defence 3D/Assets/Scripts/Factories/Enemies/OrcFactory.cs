﻿using System.Collections.Generic;
using UnityEngine;

public class OrcFactory : EnemyFactory
{
    public override TankEnemy CreateTank(List<Transform> path)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/orc_tank");
        GameObject spawned = GameObject.Instantiate(prefab);
        TankEnemy orc = spawned.GetComponent<TankEnemy>();
        orc.Init(200, 100, path, 1);

        return orc;
    }

    public override BasicEnemy CreateBasic(List<Transform> path)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/orc_basic");
        GameObject spawned = GameObject.Instantiate(prefab);
        BasicEnemy orc = spawned.GetComponent<BasicEnemy>();
        orc.Init(100, 50, path, 2);

        return orc;
    }

    public override LightEnemy CreateLight(List<Transform> path)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/orc_light");
        GameObject spawned = GameObject.Instantiate(prefab);
        LightEnemy orc = spawned.GetComponent<LightEnemy>();
        orc.Init(70, 30, path, 3);

        return orc;
    }
}