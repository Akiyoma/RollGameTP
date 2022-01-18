using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private GameObject detectGround;

    public bool start = false;
    public bool active = false;

    private bool jump = false;
    public bool isGrounded = false;
    public float jumpIntensity = 4f;
    public int jumpCount = 0;

    public SpawnPlatforms spawnPlatforms;
    
    public LayerMask groundMask;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectGround = transform.Find("DetectGround").gameObject;
    }

    private void Update() {
        if (start && Input.GetButtonDown("Jump")) {
            active = true;
            start = false;
            spawnPlatforms.start = true;
        }
        else if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < 2)) {
            jump = true;
        }
    }

    private void FixedUpdate() {
        if (active) {
            animator.SetBool("IsRunning", true);
            Vector2 detectPosition = new Vector2(detectGround.transform.position.x, detectGround.transform.position.y);
        
            if (Physics2D.OverlapCircle(detectPosition, 0.01f, groundMask)) {
                isGrounded = true;
                jumpCount = 0;
                animator.SetBool("IsJumping", false);
            }

            if (jump) {
                jump = false;
                rb.velocity = Vector2.up * jumpIntensity;
                isGrounded = false;
                jumpCount++;
                animator.SetBool("IsJumping", true);
            }
            
            if (!isGrounded) {
                animator.SetFloat("JumpVelocity", rb.velocity.y);
            }
        }
    }
}
