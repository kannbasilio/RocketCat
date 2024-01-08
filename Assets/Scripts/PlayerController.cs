using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private GameTimer gameTimer;
    private MeteorSpawner meteorSpawner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Disable gravity for 2D movement

        // Find and store a reference to the GameTimer script
        gameTimer = FindObjectOfType<GameTimer>();

        // Find and store a reference to the MeteorSpawner script
        meteorSpawner = FindObjectOfType<MeteorSpawner>();
    }

    void Update()
    {
        // Get the horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Normalize to prevent faster movement diagonally

        // Move the player using Rigidbody
        rb.velocity = movement * moveSpeed;

        // Check if the player is moving to start the game and meteor spawning
        if (!gameTimer.IsGameRunning() && movement.magnitude > 0.1f)
        {
            gameTimer.StartGame();

            // Call the StartSpawning method in the MeteorSpawner script
            if (meteorSpawner != null)
            {
                meteorSpawner.StartSpawning();
            }

        }
    }

 
}
