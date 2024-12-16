using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _destroyParticles;

    protected float MoveSpeed;
    protected float LifeTime;
    protected float Timer;
    private Transform _attackPoint;

    private float _damage;
    private float _damageMult;
    private DamageType _damageType;

    private bool _isFollowing;

    protected CombatBuilding _building;

    protected Transform CurrentTransform;
    protected Rigidbody Rigidbody;

    public bool IsFollowing => _isFollowing;
    public GameObject DestroyParticles => _destroyParticles;

    public void Init(CombatBuilding building, float moveSpeed, float lifetime, float damage, float damageMult, DamageType damageType, Transform attackPoint)
    {
        MoveSpeed = moveSpeed;
        LifeTime = lifetime;
        Timer = 0;
        _attackPoint = attackPoint;
        _damage = damage;
        _damageMult = damageMult;
        _damageType = damageType;

        _building = building;
        CurrentTransform = FindNewTarget();
        Rigidbody = GetComponent<Rigidbody>();

        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (_isFollowing)
            FollowTarget();
    }

    public void StartFollowing()
    {
        transform.position = _attackPoint.position;

        Timer = 0;
        CurrentTransform = FindNewTarget();
        _isFollowing = true;
        gameObject.SetActive(true);
    }

    public void StopFollowing()
    {
        _building.DestroyParticlesPool.Get().Play(transform.position);

        _isFollowing = false;
        gameObject.SetActive(false);
    }

    protected abstract void FollowTarget();

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.GetComponent<Enemy>() == null)
            return;

        col.collider.GetComponent<IDamagableWithEffects>().GetDamage(_damage);
        col.collider.GetComponent<IDamagableWithEffects>().GetEffect(_damageType);

        _building.ProjectilePool.Release(gameObject);
    }

    protected Transform FindNewTarget()
    {
        List<GameObject> enemies = (List<GameObject>)EnemiesData.Enemies;
        if (enemies.Count <= 0)
            return null;

        GameObject currentEnemy = enemies[0];

        foreach (GameObject enemy in enemies.Where(enemy => Vector3.Distance(enemy.transform.position, transform.position) <
                                                            Vector3.Distance(currentEnemy.transform.position, transform.position)))
        {
            currentEnemy = enemy;
        }

        return currentEnemy.transform;
    }
}
