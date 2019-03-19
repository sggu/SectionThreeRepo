using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script controls the interaction between the 
/// apple and the endbox and how it affects the life
/// </summary>
public class EndBox : MonoBehaviour {

    private int lives = 3;
    public Text livesText;
    [Space]
    public AudioSource sfx;
       
    void Start()
    {
        setText();        
    }

    void Update()
    {
        if (lives == 0)
        {
            //go through the playerpref of the high score and update
            int[] highscores = new int[10];
            for (int i = 0; i < 10; i++)
            {
                highscores[i] = PlayerPrefs.GetInt("Highscore" + i);
            }
            int curr = PlayerPrefs.GetInt("currentScore");
            for (int i = 0; i < 10; i++)
            {
                if (curr > highscores[i])
                {
                    int temp;
                    for (int j = i; j < 10; j++)
                    {
                        temp = highscores[j];
                        highscores[j] = curr;
                        curr = temp;
                    }
                }
            }
            //update the high score list
            for (int i = 0; i < 10; i++)
            {
                PlayerPrefs.SetInt("Highscore" + i, highscores[i]);
            }
            SceneManager.LoadScene("End");
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the apple hits the endbox the life goes down by one
        if (collision.gameObject.tag == "Apple")
        {            
            lives--;
            setText();
            sfx.Play();
        }
    }

    private void setText()
    {
        livesText.text = "Lives: " + lives;
    }
}