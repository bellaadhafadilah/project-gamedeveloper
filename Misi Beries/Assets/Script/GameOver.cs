using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        // Pastikan panel tidak aktif di awal
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    // Fungsi ini bisa dipanggil dari PlayerHealth.cs saat player mati
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    // Dipanggil oleh tombol "Refresh"
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Dipanggil oleh tombol "Home"
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("mainmenu"); // Ganti dengan nama scene Main Menu kamu
    }
}
