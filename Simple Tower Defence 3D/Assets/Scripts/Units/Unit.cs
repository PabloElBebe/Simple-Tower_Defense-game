using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float MaxHealth;
    protected float Armor;

    protected float Health;

    protected void Init(float maxHealth, float armor)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
        Armor = armor;
    }
}
