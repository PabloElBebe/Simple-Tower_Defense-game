using UnityEngine;

public abstract class ShardTower : CombatBuilding
{
    private float _timer;
    
    private void Update()
    {
        if (!IsPlaced)
            return;
        if (EnemiesData.Enemies.Count <= 0)
            return;

        Attack();
    }

    public override void Attack()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        else
        {
            if (GetNearestEnemy() != null && Vector3.Distance(GetNearestEnemy().position, transform.position) > AttackRange)
                return;
            
            _timer = AttackDelay;
            ProjectilePool.Get().StartFollowing();
        }
    }

    public override Projectile CreateProjectile()
    {
        Projectile projectile = ProjectileFactory.CreateShardProjectile();
        return projectile.GetComponent<Projectile>();
    }
}
