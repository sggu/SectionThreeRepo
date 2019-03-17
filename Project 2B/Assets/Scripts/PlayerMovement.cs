using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script manages the player input to move the basket and updates the score
/// </summary>
public class PlayerMovement : MonoBehaviour {
    [Header("Settings")]
    public float speed;
    public float leftAndRightEdge;
    [Space]
    public GameObject applePrefab;
    public Text scoreText;
    [Space]
    public AudioSource sfx;

    private int score = 0;

    private bool gameStarted = false;
    private bool mouseControl = false;
    private bool keyControl = false;

    void Start()
    {        
        setText();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update () {
        //if left clicked the game will use mouse control
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            mouseControl = true;
            keyControl = false;
        }
        //if space is pressed the game will use keyboard control
        else if (Input.GetKey(KeyCode.Space))
        {
            gameStarted = true;
            mouseControl = false;
            keyControl = true;
        }
        if (gameStarted) Time.timeScale = 1;

        //for mouse
        if (mouseControl)
        {
            //gets input from the mouse
            Vector3 pos = transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.x = mousePos.x;
            transform.position = pos;
            //check boundaries
            if (pos.x < -leftAndRightEdge)
            {
                transform.position = new Vector3(-leftAndRightEdge, transform.position.y, transform.position.z);
            }
            if (pos.x > leftAndRightEdge)
            {
                transform.position = new Vector3(leftAndRightEdge, transform.position.y, transform.position.z);
            }
            //press return to reset the game
            if (Input.GetKey(KeyCode.Return)) SceneManager.LoadScene("SampleScene");
        }
        //for keyboard
        else if (keyControl)
        {
            Vector3 pos = transform.position;

            //gets input for left and right
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x += -speed * Time.deltaTime;
                transform.position = pos;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += speed * Time.deltaTime;
                transform.position = pos;
            }
            //checks boundaries
            if (pos.x < -leftAndRightEdge)
            {
                transform.position = new Vector3(-leftAndRightEdge, transform.position.y, transform.position.z);
            }
            if (pos.x > leftAndRightEdge)
            {
                transform.position = new Vector3(leftAndRightEdge, transform.position.y, transform.position.z);
            }
            //press return to reset the game
            if (Input.GetKey(KeyCode.Return)) SceneManager.LoadScene("SampleScene");
        }
    }

    //checks the collision between basket and apple
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            score++;
            setText();
            sfx.Play();
        }
    }

    //sets the UI score
    private void setText()
    {
        scoreText.text = "Score: " + score;
    }
}
