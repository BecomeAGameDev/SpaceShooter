using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDrag : MonoBehaviour
{
    public float xThrust = 200f;
    public float yThrust = 200f;
    public float shipMass = 1f;
    public float drag = 1f;
    public float maxDrag = 10f;
    public float maxSpeed = 15f;

    Rigidbody2D rigidbody2d;
    Vector2 movement;
    Vector2 engineThrust;


    // Start is called before the first frame update
    void Start()
    {
        // Import rigidbody component from Player's Ship
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        // set Ship physical properties
        // TODO: put these in the ship properties script!
        rigidbody2d.mass = shipMass;
        rigidbody2d.drag = drag;

        // compute and apply force vector
        engineThrust.x = xThrust * movement.x;
        engineThrust.y = yThrust * movement.y;
        rigidbody2d.AddForce(engineThrust);

        // increase drag when Ship's speed is over maxSpeed
        if (rigidbody2d.velocity.magnitude > maxSpeed)
        {
            rigidbody2d.drag = maxDrag;
        }

        // increase drag when the ship is moving AND no input is given
        if (movement.magnitude == 0 && rigidbody2d.velocity.magnitude != 0)
        {
            rigidbody2d.drag = maxDrag / 2;
        }
    }
}
