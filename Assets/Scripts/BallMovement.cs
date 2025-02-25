using UnityEngine;
using UnityEditor;
public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Initial ball speed
    private Rigidbody2D rb;
    private const string PlayerTag = "Player";
    private const string CollisionBoundaryTag = "CollisionBoundary";
    private const string UncollisionBoundaryTag = "UncollisionBoundary";
    private const string BrickTag ="Brick";

    Color blue = new Color(0f, 0f, 1f, 1f);
    Color green = new Color(0f, 1f, 0f, 1f);
    Color white = new Color(1f, 1f, 1f, 1f);

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
            float x = CalculateBounceAngle(collision.transform.position, transform.position, collision.collider.bounds.size.x);
            rb.linearVelocity = new Vector2(x, rb.linearVelocity.y).normalized * speed;
        }
        else if(collision.gameObject.CompareTag("CollisionBoundary"))
        {
            float newX = (transform.position.x - collision.transform.position.x);
            rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y).normalized * speed;
        }
        else if(collision.gameObject.CompareTag("Top"))
        {
            float newY = (transform.position.y - collision.transform.position.y);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, newY).normalized * speed;
        }
        else if(collision.gameObject.CompareTag("Brick"))
        {
            
            BrickCollision(collision);
        }
    }

    private void BrickCollision(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().color == blue)
            collision.gameObject.GetComponent<SpriteRenderer>().color = green;
        else if (collision.gameObject.GetComponent<SpriteRenderer>().color == green)
            collision.gameObject.GetComponent<SpriteRenderer>().color = white;
        else
        //destroy the block
            Destroy(collision.gameObject);
    }
    private float CalculateBounceAngle(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.x - paddlePos.x);
    }
}
