using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JmpBhvrBasic : MonoBehaviour {

    // Use this for initialization
    PlayerStats pStats;

    float groundCheckDist = .1f;

	void Start () {
        pStats = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	public void DoBhvr () {


        if (IsGrounded())
        {
            Debug.Log("was grounded");
            pStats.rb2d.AddForce(Vector2.up * pStats.playerJumpPower);
        }
	}

    public bool IsGrounded()
    {
        bool grounded = false;

        RaycastHit2D rayHit;

        rayHit = Physics2D.Raycast(pStats.rightGroundPoint.transform.position, -Vector3.up, groundCheckDist);

        if(rayHit.collider != null)
        {
            Debug.Log("not null " + rayHit.collider.tag);
            if (rayHit.collider.tag == "Ground")
            {
                Debug.Log("is ground");
                return true;
            }
            
        }

        rayHit = Physics2D.Raycast(pStats.leftGroundPoint.transform.position, -Vector3.up, groundCheckDist);

        if (rayHit.collider != null)
        {
            if (rayHit.collider.tag == "Ground")
            {
                return true;
            }
        }

            return false;
        



    }
}
