using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float playerSpeed = 10f;
    public bool facingRight = true;
    public float playerJumpPower = 1250f;
    public float moveX;

    public Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
