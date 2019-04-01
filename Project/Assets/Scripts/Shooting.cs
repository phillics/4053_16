using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject shotType;
    private Transform playerPos;
    public int shotCapacity;
    public int coolDown = 0;
    public List<GameObject> shots = new List<GameObject>();
    public Vector3 moveDirection;
    public Projectile p;

    void Update()
    {
        playerPos = GetComponent<Transform>();
        Vector3 offset = new Vector3(0f, 10f, 0f);
        if (Input.GetMouseButtonDown(0))
        {

            if (coolDown < 10)
            {
                GameObject temp = shots[0];
                shots.RemoveAt(0);
                // Get reference to Projectile.cs
                p = temp.GetComponent<Projectile>();
                Vector3 current = p.moveDirection;
                // Increment Cooldown on player ammo store
                // Modify else branch of conditional to have
                // game show a message of some sort if player
                // needs to cooldown
                coolDown++;
                // if current is zero, projectile move vector needs to be reinitialized
                if (current == Vector3.zero)
                {
                    // Code recycled from projectile script.. recalling Start()
                    // from Projectile doesn't work the way that I hoped it would,
                    // so this ended up being the next best alternative.
                    p.moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPos.position);
                    p.moveDirection.z = 0;
                    p.moveDirection.Normalize();
                }
                // ReActivate the orb and make sure its position gets updated.
                temp.SetActive(true);
                temp.transform.position = playerPos.position + offset;
            }
            else
            {
                // see above... add something interactive here
                Debug.Log("You are out of ammo! Wait for your counter to cooldown.");
            }
        }
        else
        {
            GameObject[] activeShots = GameObject.FindGameObjectsWithTag("Projectile");
            foreach (GameObject s in activeShots)
            {
                Renderer r = s.GetComponent<Renderer>();
                if (!r.isVisible)
                {
                    // If object is no longer visible, deactivate and readd to shots list
                    s.SetActive(false);
                    shots.Add(s);
                }
            }
        }
    }

    private void Start()
    {
        // Based on current player max shot capacity,
        // we preload Orb assets into memory to prevent instantiation
        // lag when trying to shoot. 
        for(int i = 0; i < shotCapacity; i ++)
        {
            GameObject newShot = Instantiate(shotType);
            //var newShot = ObjectPoolManager.CreatePooled(shotType, Vector3.zero, Quaternion.identity);
            newShot.SetActive(false);
            shots.Add(newShot);
        }
        // InvokeRepeating calls the function in its first parameter
        // every x amount of seconds, where x is the third parameter 
        InvokeRepeating("UpdateCooldown", 0.0f, 0.1f);
    }

    private void UpdateCooldown()
    {
        if(coolDown > 0)
            coolDown--;
    }


}
