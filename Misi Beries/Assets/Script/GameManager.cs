using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton

    // Skor
    public int coinCount = 0;
    public int berryCount = 0;

    // UI
    public TextMeshProUGUI scoreText;     // Untuk coin
    public TextMeshProUGUI berryText;     // Untuk berry

    public GameObject panelGoodJob;       // Panel "Good Job"
    public bool isGamePaused = false;     // Status pause

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Tambah coin
    public void AddCoin(int coinValue)
    {
        coinCount += coinValue;
        UpdateScoreUI();
    }

    // Tambah berry
    public void AddBerry(int berryValue)
    {
        berryCount += berryValue;
        UpdateBerryUI();
    }

    // Update UI coin
    void UpdateScoreUI()
    {
        scoreText.text = "x " + coinCount;
    }

    // Update UI berry
    void UpdateBerryUI()
    {
        berryText.text = "x " + berryCount;
    }

    // Selesaikan level
    public void LevelComplete()
    {
        panelGoodJob.SetActive(true);
        PauseGame();
    }

    // Pause game
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
    }

    // Lanjut ke level berikutnya
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level2"); // Ganti sesuai nama scene
    }
}
