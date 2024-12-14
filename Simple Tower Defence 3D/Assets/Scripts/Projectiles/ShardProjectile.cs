using UnityEngine;

public class ShardProjectile : Projectile
{
    protected override void FollowTarget()
    {
        if (Timer < LifeTime)
        {
            Timer += Time.deltaTime;

            if (EnemiesData.Enemies.Count <= 0)
                return;
            if (Rigidbody == null)
                return;

            if (CurrentTransform == null)
                CurrentTransform = FindNewTarget();

            Vector3 direction = (CurrentTransform.position - transform.position).normalized;
            Rigidbody.velocity = direction * MoveSpeed;
        }
        else
            _building.ProjectilePoolPool.Release(gameObject);
    }
}
