using UnityEngine;

public class Raspberry : MonoBehaviour
{
    public int berryValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddBerry(berryValue);
            Destroy(gameObject);
        }
    }
}
