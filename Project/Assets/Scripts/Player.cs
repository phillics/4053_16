using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int health = 10;
    public float mass;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        Debug.Log(moveInput);
        if(moveInput != Vector2.zero)
        {
            anim.SetFloat("FaceX", moveInput.x);
            anim.SetFloat("FaceY", moveInput.x);
            Debug.Log(moveInput);
            anim.Play("Walk");
        } else {
            anim.SetFloat("FaceX", Vector2.zero.x);
            anim.SetFloat("FaceY", Vector2.zero.y);
            Debug.Log(moveInput);
            anim.Play("Idle");
        }



    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
