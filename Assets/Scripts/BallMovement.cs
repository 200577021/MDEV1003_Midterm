using UnityEngine;
using UnityEditor;
public class BallMovement : MonoBehaviour
{
    public float speed = 5f; 
    public int groundCollision = 0;
    public int brickCount = 9;
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
            float x = CalculateBounceAngle(collision.transform.position, transform.position, collision.collider.bounds.size.x);
            currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y * -1).normalized * GameManager.Instance.ballSpeed;
            GameManager.Instance.SetCurrentVelocity(currentVelocity);
        }
        else if(collision.gameObject.CompareTag("CollisionBoundary"))
        {
            
            Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
            currentVelocity = new Vector2(currentVelocity.x  * -1, currentVelocity.y);
            GameManager.Instance.SetCurrentVelocity(currentVelocity);
        }
        else if(collision.gameObject.CompareTag("Top"))
        {
            Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
            currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y *-1);
            GameManager.Instance.SetCurrentVelocity(currentVelocity);        
        }
        else if(collision.gameObject.CompareTag("UncollisionBoundary"))
        {
            groundCollision++;
            if(groundCollision >= 3)
            {
                GameManager.Instance.StopGame();
                Debug.Log("GAME OVERRR!");
            }
            else{
                GameManager.Instance.ResetBall();
            }

        }
        else if(collision.gameObject.CompareTag("Brick"))
        {
            
            Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
            float x = CalculateBounceAngle(collision.transform.position, transform.position, collision.collider.bounds.size.x);
            currentVelocity = new Vector2(x, currentVelocity.y * -1).normalized * GameManager.Instance.ballSpeed;
            GameManager.Instance.SetCurrentVelocity(currentVelocity);
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == blue)
                collision.gameObject.GetComponent<SpriteRenderer>().color = green;
            else if (collision.gameObject.GetComponent<SpriteRenderer>().color == green)
                collision.gameObject.GetComponent<SpriteRenderer>().color = white;
            else
            {
            //destroy the block
                Destroy(collision.gameObject);
                brickCount--;
                if(brickCount == 0)
                {
                    Debug.Log("WINNER");
                    GameManager.Instance.StopGame();

                }

            }
        }
    }

    private float CalculateBounceAngle(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.x - paddlePos.x);
    }
}

