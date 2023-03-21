using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IBaseEntity
{
    [SerializeField]
    private GameObject expPrefab;
    public BaseData.EnemyDataManager enemyData;
    private Rigidbody2D _body;
    private Transform target;
    private GameObject player;
    [SerializeField] SpriteRenderer sprite;
    public float BaseSpeed { get; set; } = 10;
    public float SmoothTime { get; set; } = 0.04f;

    private const float PlayerRange = 30;

    private void Awake()
    {
        if (enemyData.className == "Big Enemy")
        {
            enemyData.Speed = 1;
        }
        if (enemyData.className == "Small Enemy")
        {
            enemyData.Speed = 1.5f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        if (FindObjectOfType<Player>() != null)
        {
            target = FindObjectOfType<Player>().transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (Vector3.Distance(target.position, transform.position) <= enemyData.range + 20)
            {
                if (transform.position.x < player.transform.position.x)
                {
                    sprite.flipX = false;
                }
                if (transform.position.x > player.transform.position.x)
                {
                    sprite.flipX = true;
                }
                Movement();
            }
        }
    }

    public void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemyData.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
            Instantiate(expPrefab, transform.position, Quaternion.identity);
        }
    }
}
