using UnityEngine;
using UnityEngine.SceneManagement;

public class labrynthMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the movement

    private Vector2 movement;

    void Update()
    {
        // Get input from horizontal (A/D or Left/Right) and vertical (W/S or Up/Down) axes
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Apply movement to the object's position
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with a wall (tagged as "Wall")
        if (collision.gameObject.CompareTag("Mask"))
        {
            SceneManager.LoadScene("1925");
        }
    }
}

