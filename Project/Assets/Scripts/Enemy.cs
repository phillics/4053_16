using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float difference;
    private Transform playerPos;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {   
        var previousX = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        var currentX = transform.position.x;
        difference = previousX - currentX;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.health--;
            Debug.Log(player.health);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
