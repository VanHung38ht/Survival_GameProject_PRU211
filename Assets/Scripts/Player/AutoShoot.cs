using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootInterval = 0.5f;

    private GameObject[] bigEnemies;
    private GameObject[] smallEnemies;
    private GameObject nearestEnemy;
    private Transform playerTransform;
    private float lastShootTime;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        lastShootTime = Time.time;
    }

    void Update()
    {
        FindNearestEnemy();
        Shoot();
    }

    void FindNearestEnemy()
    {
        bigEnemies = GameObject.FindGameObjectsWithTag("Big Enemy");
        smallEnemies = GameObject.FindGameObjectsWithTag("Small Enemy");

        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in bigEnemies)
        {
            float distance = Vector2.Distance(playerTransform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        foreach (GameObject enemy in smallEnemies)
        {
            float distance = Vector2.Distance(playerTransform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }
    }

    void Shoot()
    {
        if (nearestEnemy == null) return;

        if (Time.time - lastShootTime >= shootInterval)
        {
            GameObject bullet = Instantiate(bulletPrefab, playerTransform.position, Quaternion.identity);
            Vector2 shootDirection = (nearestEnemy.transform.position - playerTransform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;

            lastShootTime = Time.time;
        }
    }
}
