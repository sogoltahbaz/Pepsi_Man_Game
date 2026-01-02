using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * This script manages the core game state, including scoring, high score persistence, 
 * and handling Game Over/Restart logic. It uses a static boolean to sync state 
 * across different game systems and controls the global Time Scale.
 */
public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverPanel;

    private float score = 0;
    public static bool isGameOver = false;

    void Awake()
    {
        isGameOver = false;
        Time.timeScale = 1;
    }

    void Start()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best: " + savedHighScore.ToString();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        score += Time.deltaTime * 10;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

        if (Mathf.FloorToInt(score) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Mathf.FloorToInt(score));
            highScoreText.text = "Best: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void EndGame()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Debug.Log("Game Over! Final Score: " + Mathf.FloorToInt(score));
    }

    public void RestartGame()
    {
        Debug.Log("Restart Button Clicked!");
        Time.timeScale = 1;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}