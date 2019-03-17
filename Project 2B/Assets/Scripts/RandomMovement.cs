using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the random movement of the apple tree
/// </summary>
public class RandomMovement : MonoBehaviour {
    [Header("Settings")]
    public float speed;
    public float leftAndRightEdge;
    [Space]
    public GameObject applePrefab;

    private void Start()
    {
        //will spawn apples every two seconds
        InvokeRepeating("SpawnObject", 2, 2);
    }

    public void SpawnObject()
    {
        Instantiate(applePrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //if the apple tree hits the boundaries it will be forced to turn
        if (pos.x < -leftAndRightEdge || pos.x > leftAndRightEdge) speed *= -1;
    }
    private void FixedUpdate()
    {
        //random chance of turning the other direction
        float directionChangeChance = 0.1f;
        if (Random.value <= directionChangeChance) speed *= -1;
    }
}
