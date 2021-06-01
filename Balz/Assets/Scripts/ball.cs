using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    private float YPOS,yPosTimer=2f,currtime,currCheckTime;
    ballLauncher BLbreak;
    public float GrivityScaleModifier=0.1f;
    private void Awake()
    {
        BLbreak = FindObjectOfType<ballLauncher>();
    }

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        YPOS = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        //give a constant speed to the ball
        //i guess lol
        body.velocity = body.velocity.normalized * speed*Time.deltaTime;
       // changeGavityScale();
       

    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "extraBall")
        {
            Debug.Log("Ah sexy");
            FindObjectOfType<ballLauncher>().newAddedBallCount++;

        }
    }
    void changeGavityScale()
    {
        currtime += Time.deltaTime;
        currCheckTime += Time.deltaTime;
        if (currCheckTime > 0.5f)
        {
            YPOS = transform.position.y;
            currCheckTime = 0f;
        }


        if (currtime > yPosTimer)
        {
            if (YPOS == transform.position.y)
            {
                if (BLbreak.breaking)
                    body.gravityScale = GrivityScaleModifier;
            }
            else
            {
                body.gravityScale = 0f;
            }
            currtime = 0;

        }
    }
}
