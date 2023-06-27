using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : _MonoBehaviour
{
    private static MainMenu instance;
    public static MainMenu Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MainMenu.instance != null) return;
        MainMenu.instance = this;
    }

    public void PlayGame()
    {
        StateGameCtrl.isNewGame = true;
        SceneManager.LoadScene("Game");
    }

    public void Continue()
    {
        StateGameCtrl.isNewGame = false;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
