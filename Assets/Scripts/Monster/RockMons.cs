using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMons : MonoBehaviour
{
    private float count;
    private float damageRM = 2;
    private float bloodRM = 10;
    private float speedRM = 1;
    private float attackSpeedRM = 5;
    private float expRM = 10;
    private float startTimeBtwShotsRM = 3;
    private float timeBtwShotsRM = 0;
    private float attackRangeRM = 10;
    private float attackSpeedBulletRM = 5;
    private float existenceTimeBulletRM = 3;

    private void Update()
    {
        count += Time.deltaTime;
        if (count >= 60)
        {
            count -= 60;
            damageRM += 1;
        }
    }
    public float DamageRM { get => damageRM; set => damageRM = value; }
    public float BloodRM { get => bloodRM; set => bloodRM = value; }
    public float SpeedRM { get => speedRM; set => speedRM = value; }
    public float AttackSpeedRM { get => attackSpeedRM; set => attackSpeedRM = value; }
    public float ExpRM { get => expRM; set => expRM = value; }
    public float StartTimeBtwShotsRM { get => startTimeBtwShotsRM; set => startTimeBtwShotsRM = value; }
    public float TimeBtwShotsRM { get => timeBtwShotsRM; set => timeBtwShotsRM = value; }
    public float AttackRangeRM { get => attackRangeRM; set => attackRangeRM = value; }
    public float AttackSpeedBulletRM { get => attackSpeedBulletRM; set => attackSpeedBulletRM = value; }
    public float ExistenceTimeBulletRM { get => existenceTimeBulletRM; set => existenceTimeBulletRM = value; }
}
