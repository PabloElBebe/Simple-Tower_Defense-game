using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePool : CustomPool<Projectile>
{
    private CombatBuilding _building;
    
    public ProjectilePool(CombatBuilding building, int objectsAmount)
    {
        _building = building;
        Objects = new List<Projectile>();

        for (int i = 0; i < objectsAmount; i++)
        {
            Projectile currentProjectile = building.CreateProjectile();
            Objects.Add(currentProjectile);
        }
    }

    public override Projectile Get()
    {
        Projectile currentProjectile = Objects.FirstOrDefault(obj => !obj.isActiveAndEnabled);

        if (currentProjectile == null)
            currentProjectile = Create();
        
        return currentProjectile;
    }

    public override void Release(GameObject obj)
    {
        obj.GetComponent<Projectile>().StopFollowing();
    }

    public override Projectile Create()
    {
        Projectile currentProjectile = _building.CreateProjectile();
        Objects.Add(currentProjectile);
        return currentProjectile;
    }
}
