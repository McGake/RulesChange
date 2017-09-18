using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvBhvrBasic : MonoBehaviour {


    PlayerStats pStats;

    public void Start()
    {
        pStats = GetComponent<PlayerStats>();
    }

    public void DoBhvr()
    {
        Move();
    }

    void Move()
    {
        pStats.moveX = Input.GetAxis("Horizontal");

        if (pStats.moveX < 0.0f && pStats.facingRight == false)
        {
            FlipPlayer();
        }
        else if (pStats.moveX > 0.0f && pStats.facingRight == true)
        {
            FlipPlayer();
        }

        pStats.rb2d.velocity = new Vector2(pStats.moveX * pStats.playerSpeed, pStats.rb2d.velocity.y);
    }

    void FlipPlayer()
    {
        pStats.facingRight = !pStats.facingRight;
        Vector2 localScale = pStats.transform.localScale;
        localScale.x *= -1;
        pStats.transform.localScale = localScale;
    }
}
