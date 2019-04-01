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
    public int killCount = 0;
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
        if(moveInput != Vector2.zero)
        {
            anim.SetFloat("FaceX", moveInput.x);
            anim.SetFloat("FaceY", moveInput.y);
            anim.Play("Walk");
        } else {
            anim.SetFloat("FaceX", Vector2.zero.x);
            anim.SetFloat("FaceY", Vector2.zero.y);
            anim.Play("Idle");
        }



    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
