using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public Rigidbody2D myBody;
    public Transform faceCheck;
    public LayerMask whatIsWall;
    public SpriteRenderer mySprite;

    public float moveSpeed;

    public bool hittingWall;



    private float idleTimer;

	void Start () {

        float moveMod = Random.Range(0.5f, 1.5f);

        moveSpeed *= moveMod;

	}

	void Update () {

        Move();
        IdleHandsCheck();

	}

    private void IdleHandsCheck() {

       // Debug.Log(myBody.velocity.x + " " + gameObject.name);

        if(Mathf.Abs(myBody.velocity.x) < 2f) {
            idleTimer += Time.deltaTime;
            Debug.Log("Idle");

            if(idleTimer >= 2f) {
                idleTimer = 0f;
                Vector2 dir = Random.insideUnitCircle * 1400;
                moveSpeed *= 1.25f;
                myBody.AddForce(dir);
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player") {

            float moveMod = Random.Range(.85f, 1.15f);
            moveSpeed *= moveMod;
            Flip();
        }

    }



    public void Move() {
        hittingWall = Physics2D.OverlapCircle(faceCheck.position, .01f, whatIsWall);

        //Debug.Log(hittingWall);

        if (hittingWall)
            Flip();


        myBody.velocity = new Vector2(moveSpeed * Time.deltaTime, myBody.velocity.y);

    }



    public void Flip() {

        float jumpForce = Random.Range(150f, 500f);

        myBody.AddForce(new Vector2(0f, jumpForce));

        faceCheck.localPosition = new Vector2(faceCheck.localPosition.x * -1, faceCheck.localPosition.y);
        moveSpeed *= -1;
        mySprite.flipX = !mySprite.flipX;

    }
}
