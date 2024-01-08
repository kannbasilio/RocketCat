using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionEnter : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject playAgainButton;

    void Start()
    {
        // Disable the Game Over text and play again button initially
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        if (playAgainButton != null)
        {
            playAgainButton.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<PlayerController>().enabled = false;

        // Reference to the GameTimer script
        GameTimer gameTimer = FindObjectOfType<GameTimer>();

        // Stop the timer
        if (gameTimer != null)
        {
            gameTimer.isRunning = false;
        }

        // Show game over text
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        // Show play again button
        if (playAgainButton != null)
        {
            playAgainButton.SetActive(true);
        }
    }
}
