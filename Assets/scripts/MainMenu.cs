using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string Playgamelevel;
    public string Encyclopedia;
    public string Achievements;
    public string goMainMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(Playgamelevel);
    }
    public void gotoAchievements()
    {
        SceneManager.LoadScene(Achievements);
    }
    public void gotoMainMenu()
    {
        SceneManager.LoadScene(goMainMenu);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void PlayEncyclopedia()
    {
        SceneManager.LoadScene(Encyclopedia);
    }
}
