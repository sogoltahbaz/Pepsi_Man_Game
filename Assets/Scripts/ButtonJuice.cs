/*
 * Button Visual Effects Script (Button Juice)
 * This script creates a subtle pulsing/breathing effect for UI buttons
 * using a sine wave to make the interface feel more dynamic and alive.
 */
using UnityEngine;
public class ButtonJuice : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.1f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Creates a smooth pulsing effect using a sine wave
        // Use unscaledTime so it still animates even if the game is paused (Time.timeScale = 0)
        float scale = 1f + Mathf.Sin(Time.unscaledTime * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale * scale;
    }
}