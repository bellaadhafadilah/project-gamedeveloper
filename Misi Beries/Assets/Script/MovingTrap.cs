using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 2f;

    private Vector3 startPos;
    private bool movingRight = true;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        // Knockback ke samping dan sedikit ke atas
        Vector2 knockbackDir = new Vector2(
            (other.transform.position.x - transform.position.x),
            1f
        ).normalized;

        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.Knockback(knockbackDir, 8f); // Force bisa disesuaikan
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}

}
