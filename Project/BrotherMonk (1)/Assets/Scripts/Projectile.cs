using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Vector3 moveDirection;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("orbType", 9f);
        anim.Play("Idle");
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }

    void Update()
    {
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
    }

    public void OnBecameInvisible()
    {
            Destroy(gameObject);
    }
}
