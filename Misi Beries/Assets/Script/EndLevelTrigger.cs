using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public GameManager gameManager; // Referensi ke GameManager untuk menampilkan panel

    // Fungsi ini dipanggil saat pemain memasuki trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Pastikan yang masuk adalah objek player
        if (other.CompareTag("Player"))
        {
            // Panggil fungsi di GameManager untuk menampilkan panel Good Job
            gameManager.LevelComplete();
        }
    }
}
