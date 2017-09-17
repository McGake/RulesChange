using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float playerSpeed = 10f;
    public bool facingRight = true;
    public float playerJumpPower = 750f;
    public float moveX;

    public Rigidbody2D rb2d;

    public bool onGround = false;

    public float distToGround;

    public GameObject rightGroundPoint;

    public GameObject leftGroundPoint;

    void Awake()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
    }
}
