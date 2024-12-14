using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : Enemy
{
    private float _speedMult;

    public new void Init(float health, float armor, List<Transform> path, float speedMult)
    {
        base.Init(health, armor ,path, speedMult);
        _speedMult = speedMult;
    }
}
