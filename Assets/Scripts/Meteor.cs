using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    private float speed;

    void Update()
    {
        // Move the meteor from right to left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy the meteor when it goes off the screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    // Set the speed of the meteor
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}