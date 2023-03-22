using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject monsterPrefab1;
    public float spawnRate = 300.0f; // Thời gian giữa các lần sinh ra quái vật (5 phút)
    public int numberOfMonsters = 50; // Số lượng quái vật sinh ra mỗi lần
    int rate;

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnMonsters();
            timeSinceLastSpawn = 0.0f;
        }
    }

    void SpawnMonsters()
    {
        Camera mainCamera = Camera.main;
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        for (int i = 0; i < numberOfMonsters; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-cameraWidth, cameraWidth), Random.Range(-cameraHeight, cameraHeight));
            rate = Random.Range(1, 4);
            if(rate == 1 || rate == 3)
            {
                GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            }
            if (rate == 1 || rate == 3)
            {
                GameObject monster = Instantiate(monsterPrefab1, spawnPosition, Quaternion.identity);
            }
        }
    }
}
