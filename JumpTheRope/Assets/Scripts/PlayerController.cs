using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Components {

    private Rigidbody2D rb;
    private Animator anim;

    public bool isGrounded;
    public bool isActive;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {

        if (isActive)
            if (Input.GetMouseButtonDown(0))
            {
                if (isGrounded)
                {
                    rb.AddForce(new Vector2(0, 350));
                    gm.jumpsDone++;
                    am.PlayAudio(0);
                }
            }

        if (isGrounded)
            anim.SetBool("isJumping", false);
        else
            anim.SetBool("isJumping", true);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
