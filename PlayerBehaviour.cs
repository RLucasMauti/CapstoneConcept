using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float jumpHeight = 5;
    public float moveSpeed = 10;

    private bool isFliped;
    public float groundCheckRadius;
    public Transform groundCheck;
    private bool isGrounded;
    public LayerMask whatIsGround;
    public GameObject pivot;
    public GameObject weapon;

    // Use this for initialization
    void Start () {
        isFliped = false;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        

        if (Input.GetKey(KeyCode.D))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFliped)
            {
                FlipChar();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isFliped)
            {
                FlipChar();
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            WeaponAnimation();
            weapon.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

    }

    private void FlipChar()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFliped = !isFliped;
    }

    public void WeaponAnimation()
    {
        GetComponent<Animator>().enabled = true;
    }

    public void StopWeaponAnimation()
    {
        GetComponent<Animator>().enabled = false;
        weapon.GetComponent<BoxCollider2D>().enabled = false;
    }

}
