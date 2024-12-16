using System.Collections.Generic;
using UnityEngine;

public class ElfFactory : EnemyFactory
{
    public override TankEnemy CreateTank(List<Transform> path)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/elf_tank");
        GameObject spawned = GameObject.Instantiate(prefab);
        TankEnemy elf = spawned.GetComponent<TankEnemy>();
        elf.Init(200, 50, path, 3);

        return elf;
    }

    public override BasicEnemy CreateBasic(List<Transform> path)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/elf_basic");
        GameObject spawned = GameObject.Instantiate(prefab);
        BasicEnemy elf = spawned.GetComponent<BasicEnemy>();
        elf.Init(100, 50, path, 4);

        return elf;
    }

    public override LightEnemy CreateLight(List<Transform> path)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/elf_light");
        GameObject spawned = GameObject.Instantiate(prefab);
        LightEnemy elf = spawned.GetComponent<LightEnemy>();
        elf.Init(60, 30, path, 5);

        return elf;
    }
}
