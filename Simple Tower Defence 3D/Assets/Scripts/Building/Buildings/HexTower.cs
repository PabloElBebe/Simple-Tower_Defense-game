using UnityEngine;

public abstract class HexTower : CombatBuilding
{
    private float _timer;

    private void Update()
    {
        if (!IsPlaced)
            return;
        if (EnemiesData.Enemies.Count <= 0)
            return;

        Attack();
    }

    public override void Attack()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        else
        {
            if (GetNearestEnemy() != null && Vector3.Distance(GetNearestEnemy().position, transform.position) > AttackRange)
                return;
            
            _timer = AttackDelay;
            ProjectilePoolPool.Get().StartFollowing();
        }
    }

    public override Projectile CreateProjectile()
    {
        GameObject projectile = Instantiate(Projectile, AttackPoint.position, Quaternion.identity);
        projectile.transform.SetParent(transform);
        projectile.GetComponent<Projectile>().Init(this, 8, BasicDamage * DamageMult, DamageType, 1f, AttackPoint);
        
        return projectile.GetComponent<Projectile>();
    }
}
