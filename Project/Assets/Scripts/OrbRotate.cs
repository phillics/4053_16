 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class OrbiterScript : MonoBehaviour {
 
     public GameObject attracter; // Set this to the gameobject that this gameobject will be attracted to 
 
     public float gravityConstant; // Affects strength of gravity
 
     public Vector2 startVelocity; // This will be the starting velocity of our second object (it needs to have velocity in order to orbit)
 
     private Rigidbody2D rb;
 
     private float attracterMass;
 
     // Use this for initialization
     void Start () {
        //  attracter = GameObject.Find("player");
        //  gravityConstant = 1.0;
        //  startVelocity = new Vector2(5.0, 5.0);
         rb = this.GetComponent<Rigidbody2D>();
         attracterMass = attracter.GetComponent<Rigidbody2D>().mass;
         rb.velocity = startVelocity;
     }
     
     // FixedUpdate is called once per physics update
     void FixedUpdate () {
         float distance = Vector2.Distance(this.transform.position, attracter.transform.position); // Distance between us and attracter
         Vector2 unrotatedForce = (Vector2.right * gravityConstant * attracterMass) / Mathf.Pow(distance, 2); // Magnitude of force due to gravity
 
         // Now we have to rotate that force so it's pointing towards the attracter
         Vector2 posDifference = attracter.transform.position - this.transform.position; // Difference in position
         float angleDifference = Mathf.Atan2(posDifference.y, posDifference.x); // Now, difference in angle
 
         // Now we use some trig to rotate the force vector from pointing right to pointing at the attracting object
         Vector2 rotatedForce = new Vector2(unrotatedForce.x * Mathf.Cos(angleDifference) - unrotatedForce.y * Mathf.Sin(angleDifference),
                 unrotatedForce.x * Mathf.Sin(angleDifference) + unrotatedForce.y * Mathf.Cos(angleDifference));
 
         // And now we simply add the force to our rigidbody
         rb.AddForce(rotatedForce);
     }
 }
