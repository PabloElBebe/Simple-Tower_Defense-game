using UnityEngine;

public class FireHexTower : HexTower
{
    public void Init(float attackRange, float attackDelay, float damage, float damageMult, DamageType damageType, GameObject projectile)
    {
        base.Init(attackRange, attackDelay, damage, damageType, damageMult, projectile);
    }
}
