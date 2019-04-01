using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shot;
    private Transform playerPos;
    

    void Update()
    {   
        Vector3 offset = new Vector3(0f, 10f, 0f);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shot, playerPos.position + offset, Quaternion.identity);
        }
    }

    private void Start()
    {
        playerPos = GetComponent<Transform>();
    }

   
}
