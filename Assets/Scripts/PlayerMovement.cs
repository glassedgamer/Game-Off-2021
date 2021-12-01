using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    public Animator anim;

    private bool facingRight = true;
    public bool reverseControls = false;
    public bool walkSound = false;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(reverseControls == false) {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && isGrounded == true) {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetBool("isJumping", true);
            } 
        } else if(reverseControls == true) {
            if(Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && isGrounded == true) {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetBool("isJumping", true);
            } 
        }
        if(Input.GetKeyDown(KeyCode.F)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        
        if(reverseControls == false) {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        } else if(reverseControls == true) {
            rb.velocity = new Vector2(-moveInput * speed, rb.velocity.y);
        }

        

        if(facingRight == false && moveInput > 0) {
            Flip();
        } else if(facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Ground") {
            anim.SetBool("isJumping", false);
        }
    }
}
