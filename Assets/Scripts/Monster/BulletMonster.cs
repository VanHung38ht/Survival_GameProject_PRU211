using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BulletMonster : MonoBehaviour
{
    private GameObject player;
    public GameObject MonsterRM;
    [SerializeField] GameObject bulletRM;
    private bool InRange;
    [SerializeField] private RockMons rockMons;
    public GameObject expRM;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 differance = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        if (Vector2.Distance(transform.position, player.transform.position) > rockMons.AttackRangeRM)
        {
            InRange = true;
        }
        if (Vector2.Distance(transform.position, player.transform.position) <= rockMons.AttackRangeRM)
        {
            InRange = false;
            if (rockMons.TimeBtwShotsRM <= 0)
            {
                Instantiate(bulletRM, transform.position, Quaternion.Euler(0, 0, rotZ));
                rockMons.TimeBtwShotsRM = rockMons.StartTimeBtwShotsRM;
            }
            else
            {
                rockMons.TimeBtwShotsRM -= Time.deltaTime;
            }
        }

    }

    void FixedUpdate()
    {
        if (InRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, rockMons.SpeedRM * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rockMons.AttackRangeRM);
        Gizmos.color = Color.red;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(expRM, transform.position, Quaternion.identity);
        }
    }
}
