using UnityEngine;

public abstract class ProjectileFactory
{
    public CustomPool<Particles> DestroyParticlesPool;

    public abstract Projectile CreateCrystalProjectile();
    public abstract Projectile CreateShardProjectile();
    public abstract Projectile CreateHexProjectile();
}
