using UnityEngine;

public class Raspberry : MonoBehaviour
{
    public int raspberryValue = 1;  // Nilai raspberry

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Jika yang menyentuh raspberry adalah Player
        {
            GameManager.Instance.AddCoin(raspberryValue);  // Tambahkan nilai raspberry ke GameManager
            Destroy(gameObject);  // Hapus raspberry setelah dipungut
        }
    }
}
