using UnityEngine;

public class FireCrystalTower : CrystalTower
{
    public new void Init(float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(attackRange, attackDelay, projectileFactory);
    }
}
