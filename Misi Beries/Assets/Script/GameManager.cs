using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Untuk menggunakan UI Image (progress bar)

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton

    // Skor
    public int coinCount = 0;  // Jumlah koin yang terkumpul
    public int berryCount = 0; // Jumlah berry yang terkumpul

    // UI
    public TextMeshProUGUI scoreText;     // Untuk menampilkan koin
    public TextMeshProUGUI berryText;     // Untuk menampilkan berry
    public Image targetCoinImage;         // UI Image untuk progress bar target koin
    public Image berryProgressImage;      // UI Image untuk progress bar target berry

    public GameObject panelGoodJob;       // Panel "Good Job"
    public bool isGamePaused = false;     // Status pause

    // Variabel untuk menentukan target koin dan berry per level
    public int totalCoins = 8;            // Total koin yang harus dikumpulkan (default 8)
    public int totalBerries = 11;         // Total berry yang harus dikumpulkan (level 2)
    public int level = 1;                 // Default level 1

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Fungsi untuk menambah jumlah koin
    public void AddCoin(int coinValue)
    {
        coinCount += coinValue;
        UpdateScoreUI();
        UpdateTargetProgress();  // Update progress bar setelah koin ditambah
    }

    // Fungsi untuk menambah jumlah berry
    public void AddBerry(int berryValue)
    {
        berryCount += berryValue;
        UpdateBerryUI();
        UpdateBerryProgress();  // Update progress bar untuk berry
    }

    // Update UI untuk menampilkan jumlah koin yang terkumpul
    void UpdateScoreUI()
    {
        scoreText.text = coinCount + "/" + totalCoins;  // Menampilkan "0/8" atau "3/8"
    }

    // Update UI untuk berry
    void UpdateBerryUI()
    {
        berryText.text = berryCount + "/" + totalBerries;  // Menampilkan berry
    }

    // Update progress bar untuk target koin
    void UpdateTargetProgress()
    {
        // Menghitung progres (0 - 1) berdasarkan jumlah koin
        float progress = (float)coinCount / totalCoins;
        targetCoinImage.fillAmount = progress;  // Mengubah fillAmount dari progress bar untuk koin

        // Jika koin sudah cukup (untuk level 1), atau koin dan berry sudah cukup (untuk level 2), selesaikan level
        if (coinCount >= totalCoins && (level == 1 || (level == 2 && berryCount >= totalBerries)))
        {
            LevelComplete();
        }
    }

    // Update progress bar untuk target berry
    void UpdateBerryProgress()
    {
        // Menghitung progres (0 - 1) berdasarkan jumlah berry
        float progress = (float)berryCount / totalBerries;
        berryProgressImage.fillAmount = progress;  // Mengubah fillAmount dari progress bar untuk berry

        // Jika berry sudah cukup (untuk level 2), selesaikan level
        if (berryCount >= totalBerries && coinCount >= totalCoins)
        {
            LevelComplete();
        }
    }

    // Fungsi untuk menyelesaikan level
    public void LevelComplete()
    {
        panelGoodJob.SetActive(true);  // Menampilkan panel "Good Job"
        PauseGame();  // Pause game
    }

    // Fungsi untuk pause game
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;  // Menghentikan waktu permainan
    }

    // Fungsi untuk melanjutkan ke level berikutnya
    public void NextLevel()
    {
        Time.timeScale = 1f;  // Mengaktifkan kembali waktu permainan
        SceneManager.LoadScene("level2");  // Ganti sesuai nama scene
    }
}
