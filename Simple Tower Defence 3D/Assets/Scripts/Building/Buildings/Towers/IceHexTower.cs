using UnityEngine;

public class IceHexTower : HexTower
{
    public new void Init(float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(attackRange, attackDelay, projectileFactory);
    }
}
