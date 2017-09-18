using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBhvrBasic : MonoBehaviour
{

    PlayerStats pStats;

    Vector2 tempVel;

    private bool stopAtWall = false;

    public void Start()
    {
        pStats = GetComponent<PlayerStats>();
    }

    public void DoBhvr()
    {
        if (stopAtWall)
        {
            tempVel = pStats.rb2d.velocity;

            if (pStats.facingRight)
            {
                tempVel.x = Mathf.Clamp(tempVel.x, 0f, -10000f);
            }
            else if (!pStats.facingRight)
            {
                tempVel.x = Mathf.Clamp(tempVel.x, -10000f, 0f);
            }

            pStats.rb2d.velocity = tempVel;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {       
        if (other.tag == "Ground")
        {
            stopAtWall = true;           
        }

        //Vector2[] verts = other.GetComponent<Sprite>().vertices;
        //Vector2 nearestVertex = Vector2.zero;

        //foreach(Vector2 vert in verts)
        //{
        //    Vector2 diff = vert - (Vector2)pStats.leftTrigger.transform.position;


        //}

        //if(pStats.facingRight)
        //{
        //    Vector3 tempVec;
        //    Debug.Log("facing right");
        //    tempVec = pStats.transform.position;
        //    tempVec.x += 0.2f;
        //    pStats.transform.position = tempVec;
        //}
        //else if (!pStats.facingRight)
        //{
        //    Vector3 tempVec;
        //    Debug.Log("facing left");
        //    tempVec = pStats.transform.position;
        //    tempVec.x -= 0.2f;
        //    pStats.transform.position = tempVec;
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            stopAtWall = false;
        }
    }
}
