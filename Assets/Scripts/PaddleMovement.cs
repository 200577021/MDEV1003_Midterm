using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 7f;
    public float boundary = 2.0f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);
        transform.position = newPosition; 
    }
}