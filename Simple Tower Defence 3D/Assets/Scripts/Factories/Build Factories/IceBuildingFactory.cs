using UnityEngine;

public class IceBuildingFactory : BuildingFactory
{
    public override CrystalTower CreateCrystalTower()
    {
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/crystal_tower_ice");
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/crystal_projectile_ice");
        GameObject spawned = GameObject.Instantiate(towerPrefab);
        spawned.GetComponent<IceCrystalTower>().Init(6f, 0.5f, 40f, 1f, DamageType.Ice, projectilePrefab);
        IceCrystalTower tower = spawned.GetComponent<IceCrystalTower>();
        
        return tower;
    }

    public override ShardTower CreateShardTower()
    {
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/shard_tower_ice");
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/shard_projectile_ice");
        GameObject spawned = GameObject.Instantiate(towerPrefab);
        spawned.GetComponent<IceShardTower>().Init(10f, 1.5f, 60f, 1f, DamageType.Ice, projectilePrefab);
        IceShardTower tower = spawned.GetComponent<IceShardTower>();
        
        return tower;
    }
    
    public override HexTower CreateHexTower()
    {
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/hex_tower_ice");
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/hex_projectile_ice");
        GameObject spawned = GameObject.Instantiate(towerPrefab);
        spawned.GetComponent<IceHexTower>().Init(4f, 0.2f, 20f, 1f, DamageType.Ice, projectilePrefab);
        IceHexTower tower = spawned.GetComponent<IceHexTower>();
        
        return tower;
    }
}
