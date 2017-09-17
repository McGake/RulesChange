using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JmpBhvrBasic : MonoBehaviour {

    // Use this for initialization
    PlayerStats pStats;

	void Start () {
        pStats = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	public void DoBhvr () {

        pStats.rb2d.AddForce(Vector2.up * pStats.playerJumpPower);
		
	}
}
