using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    public float damage;

    private GameObject player;


    void Awake()
    {
        //get reference for player
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //player loses grade
            player.GetComponent<Grade>().LoseGrade(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
