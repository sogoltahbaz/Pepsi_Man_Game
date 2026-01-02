using UnityEngine;
using System.Collections.Generic;

/*
 * This script handles the infinite generation and pooling of the road environment.
 * It maintains a buffer of road segments ahead of the player to ensure a seamless horizon.
 * To optimize performance and memory, it destroys the oldest road segments only after 
 * the player has safely passed them, keeping the total object count stable.
 */
public class RoadSpawner : MonoBehaviour
{
    public GameObject roadPrefab;
    public float roadLength = 10f;
    public int roadsInFront = 60;
    public int maxRoadsOnScreen = 75;

    private float nextSpawnZ = 0f;
    private Transform player;
    private List<GameObject> activeRoads = new List<GameObject>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nextSpawnZ = player.position.z - (5 * roadLength);

        for (int i = 0; i < roadsInFront; i++)
        {
            SpawnRoad();
        }
    }

    void Update()
    {
        if (player == null) return;

        if (nextSpawnZ - player.position.z < roadsInFront * roadLength)
        {
            SpawnRoad();
        }

        if (activeRoads.Count > maxRoadsOnScreen)
        {
            RemoveOldRoad();
        }
    }

    void SpawnRoad()
    {
        GameObject road = Instantiate(roadPrefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity);
        activeRoads.Add(road);
        nextSpawnZ += roadLength;
    }

    void RemoveOldRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}