using System.Collections;
using UnityEngine;

public class ElfTank : TankEnemy, IFlammable
{
    public IEnumerator Flame()
    {
        float timer = 2;
        
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            GetComponent<IDamagableWithEffects>().GetDamage(5);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
