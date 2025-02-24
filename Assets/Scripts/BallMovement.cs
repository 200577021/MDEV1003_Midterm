using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Initial ball speed
    private Rigidbody2D rb;
    private const string PlayerTag = "Player";
    private const string CollisionBoundaryTag = "CollisionBoundary";
    private const string UncollisionBoundaryTag = "UncollisionBoundary";

  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // Launch ball in a random upward direction
        float randomX = Random.Range(-1f, 1f);
        rb.linearVelocity = new Vector2(randomX, 1).normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add slight variation to bounce direction
            float newX = (transform.position.x - collision.transform.position.x);
            rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y).normalized * speed;
        }
    }
}