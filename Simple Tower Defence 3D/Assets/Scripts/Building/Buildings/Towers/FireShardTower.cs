using UnityEngine;

public class FireShardTower : ShardTower
{
    public new void Init(int price, float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(price, attackRange, attackDelay, projectileFactory);
    }
}
