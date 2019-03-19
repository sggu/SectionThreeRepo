using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script controls what happens at the end menu of the game
/// </summary>
public class End : MonoBehaviour {

    public List<Text> highscoreList;

    private void Start()
    {
        //Updates and sets text for the high score
        for (int i = 0; i < 10; i++)
        {
            highscoreList[i].text = "" + PlayerPrefs.GetInt("Highscore" + i);
        }
    }
    //repeat of codes from menu.cs
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void toMenu()
    {
        SceneManager.LoadScene("Begin");
    }
}
