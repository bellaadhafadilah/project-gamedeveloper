using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;  // Nilai koin

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Jika yang menyentuh koin adalah Player
        {
            GameManager.Instance.AddCoin(coinValue);  // Tambahkan koin ke GameManager
            Destroy(gameObject);  // Hapus koin setelah dipungut
        }
    }
}
