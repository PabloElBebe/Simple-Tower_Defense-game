using UnityEngine;

public class IceCrystalTower : CrystalTower
{
    public new void Init(float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(attackRange, attackDelay, projectileFactory);
    }
}
