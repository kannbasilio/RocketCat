using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    private bool messageShown = false;

    void Update()
    {
        // Check if the player is moving
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool playerMoving = horizontalInput != 0f || verticalInput != 0f;

        // If the player is moving and the message is still visible, hide it
        if (playerMoving && !messageShown)
        {
            HideMessage();
        }

        // Optionally, you can add conditions to display the message under specific circumstances.
    }

    void HideMessage()
    {
        // Hide the message
        messageText.gameObject.SetActive(false);

        // Set a flag to prevent hiding the message repeatedly
        messageShown = true;

    }
}