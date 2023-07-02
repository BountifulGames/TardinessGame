using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //public SpriteRenderer sign;
    private bool checkpointClicked;
    private GameObject timer;
    public Animator anim;
    public AudioClip checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        checkpointClicked = false;
        timer = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (!checkpointClicked)
            {
                GameManager.gm.checkpointLocation = new Vector2(other.transform.position.x, other.transform.position.y + 1);
                timer.GetComponent<Timer>().RecordTime();
                anim.SetTrigger("Checkpoint");
                //sign.color = Color.green;
                checkpointClicked = true;
                GameManager.gm.isCheckpoint = true;
                SoundManager.instance.PlaySound(checkpoint, 1);
            }
        }
    }
}
