/*
 * Player Movement Control Script (Twilight)
 * This script handles automatic forward movement, switching between 3 lanes (Left, Middle, Right),
 * and detecting obstacle collisions to end the game.
 */
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int currentLane = 1;
    public float laneDistance = 3.0f;
    public float forwardSpeed = 10f;
    public float laneChangeSpeed = 10.0f;
    private bool isGameOver = false;
    void Update()
    {
        if (isGameOver) return;
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < 2) currentLane++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > 0) currentLane--;
        }
        Vector3 targetPosition = transform.position;
        if (currentLane == 0) targetPosition.x = -laneDistance;
        else if (currentLane == 1) targetPosition.x = 0;
        else if (currentLane == 2) targetPosition.x = laneDistance;
        Vector3 newPos = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * laneChangeSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isGameOver = true;
            forwardSpeed = 0;
        }
    }
}