using UnityEngine;
using UnityEngine.UI; // ini penting untuk Button
using TMPro;
public class DialogBoxController : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public Button nextButton;

    public PlayerMovement playerMovementScript; // ⬅️ Tambahkan ini

    private string[] messages = {
        "Di Level ini ada TrapBomb!",
        "Hindari agar nyawa kamu tidak berkurang!",
        "Klik 'Mulai' untuk lanjut bermain."
    };

    private int currentMessage = 0;

    void Start()
    {
        dialogPanel.SetActive(true);
        dialogText.text = messages[currentMessage];
        nextButton.onClick.AddListener(ShowNextMessage);

        playerMovementScript.canMove = false; // ⛔ Matikan gerakan
    }

    void ShowNextMessage()
    {
        currentMessage++;
        if (currentMessage < messages.Length)
        {
            dialogText.text = messages[currentMessage];
        }
        else
        {
            dialogPanel.SetActive(false);
            playerMovementScript.canMove = true; // ✅ Aktifkan gerakan kembali
        }
    }
}
