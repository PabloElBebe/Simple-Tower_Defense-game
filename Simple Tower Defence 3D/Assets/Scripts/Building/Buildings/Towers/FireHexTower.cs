﻿using UnityEngine;

public class FireHexTower : HexTower
{
    public new void Init(int price, float attackRange, float attackDelay, ProjectileFactory projectileFactory)
    {
        base.Init(price, attackRange, attackDelay, projectileFactory);
    }  
}
