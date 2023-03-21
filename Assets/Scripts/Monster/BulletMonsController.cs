using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BulletMonsController : MonoBehaviour
{
    [SerializeField] private RockMons rockMons;

    void Start()
    {
        Invoke("DestroyBulletMonster", rockMons.ExistenceTimeBulletRM);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * rockMons.AttackSpeedBulletRM * Time.deltaTime);
    }

    void DestroyBulletMonster()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}
