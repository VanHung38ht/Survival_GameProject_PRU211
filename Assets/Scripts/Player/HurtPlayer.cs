using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    [SerializeField]
    private Enemy enemy;
    private HealthManager healthManager;
    //private RockMons rockMons;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthManager.HurtPlayer(enemy.enemyData.meleeDamage);
            //healthManager.HurtPlayer(rockMons.DamageRM);
        }
    }
}
