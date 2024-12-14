using UnityEngine;

public class CrystalProjectile : Projectile
{
    protected override void FollowTarget()
    {
        if (Timer < LifeTime)
        {
            Timer += Time.deltaTime;

            if (CurrentTransform == null)
                return;
            if (Rigidbody == null)
                return;

            Vector3 direction = (CurrentTransform.position - transform.position).normalized;
            Rigidbody.velocity = direction * MoveSpeed;
        }
        else
            _building.ProjectilePool.Release(gameObject);
    }
}
