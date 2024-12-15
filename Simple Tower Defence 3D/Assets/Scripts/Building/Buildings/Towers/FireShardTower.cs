using UnityEngine;

public class FireShardTower : ShardTower
{
    public new void Init(float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(attackRange, attackDelay, projectileFactory);
    }
}
