using UnityEngine;

public class FireHexTower : HexTower
{
    public new void Init(float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(attackRange, attackDelay, projectileFactory);
    }   
}
