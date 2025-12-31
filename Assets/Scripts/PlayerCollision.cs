/*
 * Player Collision Management Script
 * This script detects collisions with objects tagged as "Obstacle"
 * and triggers the EndGame method from the GameManager upon impact.
 */
using UnityEngine;
public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.EndGame();
            }
        }
    }
}