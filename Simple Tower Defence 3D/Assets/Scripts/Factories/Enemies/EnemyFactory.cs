using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory
{
    public abstract TankEnemy CreateTank(List<Transform> path);
    public abstract BasicEnemy CreateBasic(List<Transform> path);
    public abstract LightEnemy CreateLight(List<Transform> path);
}
