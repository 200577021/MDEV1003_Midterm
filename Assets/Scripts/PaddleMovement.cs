using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10f;
    public float boundary = 2.0f; 


    void Update()
    {
        // Keyboard Input (for PC testing)
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Mobile Input (Touch Controls)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = new Vector3(Mathf.Clamp(touchPos.x, -boundary, boundary), transform.position.y, 0);
        }
        else
        {
            // Move paddle
            transform.position += new Vector3(move, 0, 0);
        }

        // Keep paddle within screen bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -boundary, boundary), transform.position.y, 0);
    }
}
