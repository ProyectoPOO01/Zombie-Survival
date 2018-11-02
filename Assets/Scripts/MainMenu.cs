using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject instructions;
    public GameObject backButton;


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowInstructions()
    {
        instructions.SetActive(true);
        backButton.SetActive(true);
    }

    public void GoBack()
    {
        instructions.SetActive(false);
        backButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
