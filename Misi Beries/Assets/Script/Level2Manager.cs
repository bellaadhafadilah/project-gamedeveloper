using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Untuk manajemen scene

public class Level2Manager : MonoBehaviour
{
    public static Level2Manager Instance;  // Singleton untuk mengakses Level2Manager dari skrip lain

    public int coinCount = 0;  // Skor koin yang dikumpulkan pemain
    public int raspberryCount = 0;  // Skor raspberry yang dikumpulkan pemain
    public TextMeshProUGUI scoreText;  // Referensi untuk UI TextMeshPro untuk menampilkan skor
    public GameObject panelGoodJob;  // Referensi untuk panel "Good Job" yang muncul saat level selesai

    public bool isGamePaused = false;  // Status game, apakah game sedang dijeda atau tidak

    private void Awake()
    {
        // Membuat instance Level2Manager jika belum ada
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

    // Fungsi untuk menambah skor raspberry
    public void AddRaspberry(int raspberryValue)
    {
        raspberryCount += raspberryValue;  // Menambah skor raspberry
        UpdateScoreUI();  // Memperbarui tampilan skor
    }

    // Fungsi untuk memperbarui tampilan skor di UI
    void UpdateScoreUI()
    {
        scoreText.text = "Coins: " + coinCount + " | Raspberries: " + raspberryCount;  // Menampilkan skor pada UI
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
        SceneManager.LoadScene("level3"); // Ganti dengan nama scene level berikutnya (misalnya "Level2")
    }
}
