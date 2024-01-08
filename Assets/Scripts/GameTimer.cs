using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float currentTime { get; private set; }
    public float bestTime { get; private set; }
    public bool isRunning = false;
    private bool playerStartedMoving = false;

    void Start()
    {
        // Load the best time from PlayerPrefs
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
    }

    void Update()
    {
        // Check if the player has started moving before updating the timer
        if (playerStartedMoving && isRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // Format the time as minutes, seconds, and milliseconds
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        string milliseconds = ((currentTime * 100) % 100).ToString("00");

        // Update the TextMeshProUGUI text
        timerText.text = "Time: " + minutes + ":" + seconds + ":" + milliseconds;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with something
        if (other.CompareTag("Obstacle"))
        {
            // Stop the timer when the collision occurs
            isRunning = false;

            // Save the best time if the current time is better
            if (currentTime < bestTime || bestTime == 0f)
            {
                bestTime = currentTime;
                PlayerPrefs.SetFloat("BestTime", bestTime);
                Debug.Log("New best time: " + bestTime);
            }

            // Perform additional actions when the collision occurs (e.g., end the game)
            Debug.Log("Collision detected! Time stopped: " + currentTime);

            // You can add more functionality here, like ending the game or displaying a message.
        }
    }

    // Called when the player starts moving the sprite
    public void StartGame()
    {
        if (!playerStartedMoving)
        {
            playerStartedMoving = true;
            isRunning = true; // Start the timer when the player starts moving
        }
    }

    // Public method to check if the game is running (accessible from other scripts)
    public bool IsGameRunning()
    {
        return isRunning;
    }
}
