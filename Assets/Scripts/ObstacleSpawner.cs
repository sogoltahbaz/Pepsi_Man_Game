/*
 * اسکریپت تولید خودکار موانع
 * این اسکریپت با محاسبه مسافت طی شده توسط بازیکن، موانع را در فواصل تصادفی
 * و در یکی از سه لاین اصلی به صورت بی‌نهایت تولید می‌کند.
 */
using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    [Header("Distance Settings")]
    public float minDistance = 10f;
    public float maxDistance = 20f;
    [Header("Position Settings")]
    public float forwardOffset = 50f;
    public float laneDistance = 5.0f;
    public float xOffset = 0f;
    private float lastSpawnZ = 0f;
    private float nextSpawnDistance;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            lastSpawnZ = player.transform.position.z;
        }
        nextSpawnDistance = Random.Range(minDistance, maxDistance);
    }

    void Update()
    {
        if (GameManager.isGameOver || player == null) return;
        float distanceTraveled = player.transform.position.z - lastSpawnZ;
        if (distanceTraveled >= nextSpawnDistance)
        {
            SpawnObstacle();
            lastSpawnZ = player.transform.position.z;
            nextSpawnDistance = Random.Range(minDistance, maxDistance);
        }
    }

    void SpawnObstacle()
    {
        float[] lanes = { -laneDistance, 0f, laneDistance };
        float randomX = lanes[Random.Range(0, lanes.Length)];
        float spawnZ = player.transform.position.z + forwardOffset;
        Vector3 spawnPos = new Vector3(randomX + xOffset, 0.5f, spawnZ);
        GameObject newObstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPos, Quaternion.identity);
        Destroy(newObstacle, 10f);
    }
}