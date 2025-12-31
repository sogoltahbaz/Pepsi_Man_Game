using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverPanel;

    private float score = 0;

    // استفاده از متغیر Static برای هماهنگی آنی تمام اسکریپت‌ها
    public static bool isGameOver = false;

    void Awake()
    {
        // حتماً در شروع بازی مقدار را ریست کن
        isGameOver = false;
        Time.timeScale = 1;
    }

    void Start()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best: " + savedHighScore.ToString();

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    void Update()
    {
        // اگر باختیم، هیچ اتفاقی نیفتد (امتیاز متوقف می‌شود)
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

        isGameOver = true; // توقف فوری
        Time.timeScale = 0; // توقف فیزیک

        if (gameOverPanel != null) gameOverPanel.SetActive(true);

        Debug.Log("Game Over! Final Score: " + Mathf.FloorToInt(score));
    }

    public void RestartGame()
    {
        Debug.Log("Restart Button Clicked!"); // این خط را برای تست اضافه کن
        Time.timeScale = 1;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}