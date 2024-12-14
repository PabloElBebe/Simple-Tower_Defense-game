using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CombatBuilding : Building, IAttacker
{
    protected float BasicDamage;
    protected float DamageMult;
    protected float AttackRange;
    protected float AttackDelay;

    protected DamageType DamageType;
    
    public CustomPool<Projectile> ProjectilePoolPool;
    public CustomPool<Particles> DestroyParticlesPool;

    [SerializeField] protected GameObject Projectile;
    [SerializeField] protected Transform AttackPoint;

    protected void Init(float attackRange, float attackDelay, float damage, DamageType damageType, float damageMult, GameObject projectile)
    {
        AttackRange = attackRange;
        AttackDelay = attackDelay;
        BasicDamage = damage;
        DamageMult = damageMult;
        Projectile = projectile;

        DamageType = damageType;

        ProjectilePoolPool = new ProjectilePool(GetComponent<CombatBuilding>(), 3);
        DestroyParticlesPool = new DestroyParticlesPool(projectile.GetComponent<Projectile>().DestroyParticles, transform, 1);
    }

    public abstract void Attack();

    protected Transform GetNearestEnemy()
    {
        List<GameObject> enemies = (List<GameObject>)EnemiesData.Enemies;
        if (enemies.Count <= 0)
            return null;

        GameObject currentEnemy = enemies[0];
        
        foreach (GameObject enemy in enemies.Where(enemy => Vector3.Distance(enemy.transform.position, transform.position) < 
                                                            Vector3.Distance(currentEnemy.transform.position, transform.position)))
        {
            currentEnemy = enemy;
        }

        return currentEnemy.transform;
    }
    
    public abstract Projectile CreateProjectile();
}
