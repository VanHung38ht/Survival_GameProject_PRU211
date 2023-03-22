using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BulletMonsController : MonoBehaviour
{
    [SerializeField] private RockMons rockMons;
    //private HealthManager healthManager;
    void Start()
    {
        Invoke("DestroyBulletMonster", rockMons.ExistenceTimeBulletRM);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * rockMons.AttackSpeedBulletRM * Time.deltaTime);
       // healthManager = FindObjectOfType<HealthManager>();
    }

    void DestroyBulletMonster()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        //    healthManager.HurtPlayer(2);
            Destroy(gameObject);

        }
    }
}
