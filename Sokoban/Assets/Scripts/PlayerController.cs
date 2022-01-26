using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Animator animator;
    public float speed = 5f;

    public List<Vector3> previousPos;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0f, moveY).normalized;
        
        rb.velocity = new Vector3(moveX * speed, rb.velocity.y, moveY * speed);
        
        animator.SetFloat("MoveX", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("MoveY", Mathf.Abs(rb.velocity.z));

        if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.z) > 0) {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
