/*
 * Object Cleanup Script (Destroyer)
 * This script optimizes the game by destroying obstacles or road segments 
 * once the player has passed them by a certain distance.
 */
using UnityEngine;
public class Destroyer : MonoBehaviour
{
    private Transform playerTransform;
    public float deleteDistance = 10f;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            if (playerTransform.position.z > transform.position.z + deleteDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}