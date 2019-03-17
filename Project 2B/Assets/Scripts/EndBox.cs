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
            SceneManager.LoadScene("SampleScene");
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
