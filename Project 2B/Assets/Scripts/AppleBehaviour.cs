using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script manages the apple's behavior when it collides with other objects
/// </summary>
public class AppleBehaviour : MonoBehaviour {

    public GameObject applePrefab;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the apple hits the basket it is destroyed
        if (collision.gameObject.tag == "Player")
        {
            Destroy(applePrefab);        
        }
        //if the apple hits the endbox it is destroyed
        //(loss of lives is processed by the endbox) 
        if (collision.gameObject.tag == "EndBox")
        {
            Destroy(applePrefab);
        }
    }
}
