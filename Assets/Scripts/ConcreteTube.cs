using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteTube : MonoBehaviour
{

    [Header("References")]
    private GameObject player;
    private GameObject parentTube;
    private Color alpha;

    void Awake()
    {
        //get reference for player
        player = GameObject.Find("Player");
        //get parent object reference
        parentTube = this.transform.parent.gameObject;
        alpha = parentTube.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //set alpha to 20 percent
            alpha.a = 0.2f;
            parentTube.GetComponent<SpriteRenderer>().color = alpha;
            Debug.Log("Enter Tube");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //revert to no alpha
            alpha.a = 1f;
            parentTube.GetComponent<SpriteRenderer>().color = alpha;
            Debug.Log("Exit Tube");
        }
    }


}
