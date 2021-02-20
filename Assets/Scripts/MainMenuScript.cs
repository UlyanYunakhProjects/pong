using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject mainMenu;

    public void StarSoloGame()
    {
        SceneManager.LoadScene("Game");
        GameMode.AIEnable = true;
        GameMode.AITurn = false;
    }

    public void Star2PlayersGame()
    {
        SceneManager.LoadScene("Game");
        GameMode.AIEnable = false;
    }

    public void ViewControls()
    {
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void RerurnToMainMenu()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
