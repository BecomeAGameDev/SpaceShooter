using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int Thrust;
    int shipMass;
    int shipDrag;
    int maxSpeed;

    Rigidbody2D rb;
    Vector2 movement;
    Vector2 engineThrust;


    // Start is called before the first frame update
    void Start()
    {
        // Import rigidbody component from Player's Ship
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // get player input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate is called every 0.02 seconds, is frame independent
    void FixedUpdate()
    {
        // Getting properties from ShipStats.cs
        // TODO: sarebbe bello spostare questi in una funzione che si attivi solo se cambiano
        Thrust = GetComponent<ShipStats>().shipProperties.thrust;
        shipMass = GetComponent<ShipStats>().shipProperties.mass;
        shipDrag = GetComponent<ShipStats>().shipProperties.drag;
        maxSpeed = GetComponent<ShipStats>().shipProperties.maxSpeed;

        // set Ship physical properties
        // TODO: sarebbe bello spostare questi in una funzione che si attivi solo se cambiano
        rb.mass = shipMass;
        rb.drag = shipDrag;

        // compute and apply force vector
        engineThrust.x = Thrust * movement.x;
        engineThrust.y = Thrust * movement.y;
        
        rb.AddForce(engineThrust);
        rb.AddForce(-engineThrust * rb.velocity.magnitude/maxSpeed);
    }
}
