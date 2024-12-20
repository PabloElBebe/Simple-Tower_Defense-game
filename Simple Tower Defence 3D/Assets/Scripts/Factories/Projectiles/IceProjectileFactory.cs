﻿using UnityEngine;

public class IceProjectileFactory : ProjectileFactory
{
    private CombatBuilding _building;
    private Transform _attackPoint;

    public IceProjectileFactory(CombatBuilding building, Transform attackPoint)
    {
        _building = building;
        _attackPoint = attackPoint;
        
        GameObject particlesPrefab = Resources.Load<GameObject>("Prefabs/Particles/destroy_particles_ice");
        DestroyParticlesPool = new DestroyParticlesPool(particlesPrefab, building.transform, 1);
    }
    
    public override Projectile CreateCrystalProjectile()
    {   
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/crystal_projectile_ice");
        GameObject spawned = GameObject.Instantiate(projectilePrefab, _building.transform);
        spawned.GetComponent<CrystalProjectile>().Init(_building, 6f, 1f, 40f, 1f, DamageType.Ice, _attackPoint);
        CrystalProjectile projectile = spawned.GetComponent<CrystalProjectile>();

        return projectile;
    }

    public override Projectile CreateShardProjectile()
    {
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/shard_projectile_ice");
        GameObject spawned = GameObject.Instantiate(projectilePrefab, _building.transform);
        spawned.GetComponent<ShardProjectile>().Init(_building, 4f, 4f, 60f, 1f, DamageType.Ice, _attackPoint);
        ShardProjectile projectile = spawned.GetComponent<ShardProjectile>();

        return projectile;
    }

    public override Projectile CreateHexProjectile()
    {
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectiles/hex_projectile_ice");
        GameObject spawned = GameObject.Instantiate(projectilePrefab, _building.transform);
        spawned.GetComponent<HexProjectile>().Init(_building, 10f, 0.5f, 15f, 1f, DamageType.Ice, _attackPoint);
        HexProjectile projectile = spawned.GetComponent<HexProjectile>();

        return projectile;
    }
}
