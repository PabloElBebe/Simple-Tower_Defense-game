using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Unit, IWalking, IDamagableWithEffects
{
    private float _effectSpeedMult;
    
    protected void Init(float health, float armor, List<Transform> path, float speedMult)
    {
        base.Init(health, armor);
        _effectSpeedMult = 1;
        StartCoroutine(GoByThePath(path, speedMult));
    }

    public void GetDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException();

        Health = Mathf.Clamp(Health - damage, 0, MaxHealth);

        if (Health == 0)
        {
            EnemiesData.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    public void GetEffect(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Fire:
                
                break;
            case DamageType.Ice:
                _effectSpeedMult -= 0.15f;

                if (_effectSpeedMult < 0.4f)
                    _effectSpeedMult = 0.4f;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null);
        }
    }
    
    public IEnumerator GoByThePath(List<Transform> path, float speedMult)
    {
        foreach (Transform point in path)
        {
            Vector3 currentPos = new Vector3(point.position.x, 1.25f, point.position.z);
            
            RotateToPoint(transform.position, currentPos);
            
            while (Vector3.Distance(transform.position, currentPos) > 0.1f)
            {
                Vector3 direction = (currentPos - transform.position).normalized;
                transform.Translate(direction * Time.deltaTime * speedMult * _effectSpeedMult, Space.World);
                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void RotateToPoint(Vector3 currentPos, Vector3 pointPos)
    {
        transform.localRotation = Quaternion.LookRotation(currentPos - pointPos);
    }
}
