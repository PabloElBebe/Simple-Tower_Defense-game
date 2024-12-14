using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CombatBuilding : Building, IAttacker
{
    protected float AttackRange;
    protected float AttackDelay;

    protected ProjectileFactory ProjectileFactory;
    
    public CustomPool<Projectile> ProjectilePool;
    public CustomPool<Particles> DestroyParticlesPool;

    [SerializeField] protected GameObject Projectile;
    [SerializeField] protected Transform AttackPoint;

    protected void Init(float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        AttackRange = attackRange;
        AttackDelay = attackDelay;
        ProjectileFactory = projectileFactory;

        ProjectilePool = new ProjectilePool(GetComponent<CombatBuilding>(), 3);
        DestroyParticlesPool = ProjectileFactory.DestroyParticlesPool;
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
