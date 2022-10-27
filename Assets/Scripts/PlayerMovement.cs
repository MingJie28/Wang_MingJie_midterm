using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    [SerializeField] private Transform posGroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float groundRadius;
    private bool isGrounded = false;
    public Animator animator;


    // Update is called once per frame
    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);
        isGrounded = GroundCheck();
        animator.SetBool("isGrounded", isGrounded);
        

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }

        DuckAnimation(horiz);
        MovingAnimation(horiz);




        animator.SetFloat("ySpeed", rb.velocity.y);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(posGroundCheck.position, groundRadius, GroundLayer);
    }


    private void DuckAnimation(float horiz)
    {
        if (isGrounded && Input.GetKey(KeyCode.S) && horiz == 0)
        {
            animator.SetBool("isDucking", true);
        }
        else
        {
            animator.SetBool("isDucking", false);
        }
    }

    private void MovingAnimation(float horiz)
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("xSpeed", 1.0f);
            this.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("xSpeed", 1.0f);
            this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else
        {
            animator.SetFloat("xSpeed", 0.0f);
        }
    }
}
