using UnityEngine;

public class FireCrystalTower : CrystalTower
{
    public new void Init(int price, float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(price, attackRange, attackDelay, projectileFactory);
    }
}
