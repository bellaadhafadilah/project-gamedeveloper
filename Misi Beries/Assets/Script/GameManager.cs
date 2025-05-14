using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Untuk manajemen scene

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton untuk mengakses GameManager dari skrip lain

    public int coinCount = 0;  // Skor koin yang dikumpulkan pemain
    public TextMeshProUGUI scoreText;  // Referensi untuk UI TextMeshPro untuk menampilkan skor
    public GameObject panelGoodJob;  // Referensi untuk panel "Good Job" yang muncul saat level selesai

    public bool isGamePaused = false;  // Status game, apakah game sedang dijeda atau tidak

    private void Awake()
    {
        // Membuat instance GameManager jika belum ada
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Fungsi untuk menambah skor koin
    public void AddCoin(int coinValue)
    {
        coinCount += coinValue;  // Menambah skor koin
        UpdateScoreUI();  // Memperbarui tampilan skor
    }

    // Fungsi untuk memperbarui tampilan skor di UI
    void UpdateScoreUI()
    {
        scoreText.text = "Coins: " + coinCount;  // Menampilkan skor pada UI
    }

    // Fungsi ini dipanggil ketika level selesai
    public void LevelComplete()
    {
        // Tampilkan panel "Good Job"
        panelGoodJob.SetActive(true);

        // Pause permainan
        PauseGame();
    }

    // Fungsi untuk mem-pause permainan
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;  // Menjeda waktu permainan
    }

    // Fungsi untuk melanjutkan ke level berikutnya
    public void NextLevel()
    {
        Time.timeScale = 1f;  // Mengaktifkan kembali waktu permainan
        SceneManager.LoadScene("level2"); // Ganti dengan nama scene level berikutnya (misalnya "Level2")
    }
}
