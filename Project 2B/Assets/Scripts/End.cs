using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

    public List<Text> highscoreList;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            highscoreList[i].text = "" + PlayerPrefs.GetInt("Highscore" + i);
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitGame()
    {
        Application.Quit();
        //Debug.Log("exiting game");
    }
    public void toMenu()
    {
        SceneManager.LoadScene("Begin");
    }
}
