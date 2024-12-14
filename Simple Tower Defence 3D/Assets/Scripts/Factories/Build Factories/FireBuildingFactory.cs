using UnityEngine;

public class FireBuildingFactory : BuildingFactory
{
    public override CrystalTower CreateCrystalTower()
    {
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/crystal_tower_fire");
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/crystal_projectile_fire");
        GameObject spawned = GameObject.Instantiate(towerPrefab);
        spawned.GetComponent<FireCrystalTower>().Init(6f, 0.5f, 40f, 1f, DamageType.Fire, projectilePrefab);
        FireCrystalTower tower = spawned.GetComponent<FireCrystalTower>();
        
        return tower;
    }

    public override ShardTower CreateShardTower()
    {
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/shard_tower_fire");
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/shard_projectile_fire");
        GameObject spawned = GameObject.Instantiate(towerPrefab);
        spawned.GetComponent<FireShardTower>().Init(10f, 1.5f, 60f, 1f, DamageType.Fire, projectilePrefab);
        FireShardTower tower = spawned.GetComponent<FireShardTower>();
        
        return tower;
    }

    public override HexTower CreateHexTower()
    {
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/hex_tower_fire");
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/hex_projectile_fire");
        GameObject spawned = GameObject.Instantiate(towerPrefab);
        spawned.GetComponent<FireHexTower>().Init(4f, 0.2f, 20f, 1f, DamageType.Fire, projectilePrefab);
        FireHexTower tower = spawned.GetComponent<FireHexTower>();
        
        return tower;
    }
}
