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
            
            Debug.Log(tempVel.x + " " + tempVel.y);

            pStats.rb2d.velocity = tempVel;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {       
        if (other.tag == "Ground")
        {
            stopAtWall = true;           
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            stopAtWall = false;
        }
    }
}
