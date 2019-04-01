using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public float maxSpeed = 10;
    private bool facingRight = true;
    Animator a;
    // Start is called before the first frame update
    void Start()
    {
       a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float move = Input.GetAxis("Horizontal");
        //a.SetFloat("Speed", Mathf.Abs(move));
        //var rb = GetComponent<Rigidbody2D>();
        Enemy es = GetComponent<Enemy>();
        a.SetFloat("speed", Mathf.Abs(es.difference));
        //rb.velocity = new Vector2(move * es.speed, rb.velocity.y);
        if(es.difference > 0 && facingRight)
            Flip();
        else if(es.difference < 0 &&!facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player"))
        {
            a.SetTrigger("Attack");
        }
    }
}
