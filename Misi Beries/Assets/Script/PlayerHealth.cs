using UnityEngine;
using TMPro; // jika kamu pakai TextMeshPro
using UnityEngine.UI; // untuk Panel

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI heartText;

    [Header("UI Game Over")]
    public GameObject gameOverPanel; // Drag panel di sini

    private void Start()
    {
        UpdateHealthUI();

        // Pastikan panel mati di awal
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player health: " + health);
        UpdateHealthUI();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player mati!");
        gameObject.SetActive(false);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ShowGameOver();
        }
    }


    private void UpdateHealthUI()
    {
        if (heartText != null)
        {
            heartText.text = health.ToString();
        }
    }
}
