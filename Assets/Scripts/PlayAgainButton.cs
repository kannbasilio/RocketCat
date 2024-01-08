using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    public Button playAgainButton;

    void Start()
    {
        playAgainButton = GetComponent<Button>();

    }

    public void OnPlayAgainButtonClick()
    {
        SceneManager.LoadScene("RocketCat");
    }

}
