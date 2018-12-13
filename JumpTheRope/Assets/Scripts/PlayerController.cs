using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private bool isGrounded;

    public int jump;
    public GameObject rope;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0, jump));
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rope"))
        {
            if (isGrounded)
            {
                Debug.Log("You Lost");
                rope.GetComponent<Animator>().speed = 0;
            }
        }
    }
}
