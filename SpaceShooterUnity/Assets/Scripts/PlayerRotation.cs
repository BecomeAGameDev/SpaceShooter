using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    int torqueThrust;
    int angularDrag;

    Rigidbody2D rb;
    Vector3 mousePos;
    Vector2 mouseDir;
    Vector2 shipDir;
    float dirAngle;
    float dirSign;


    // Start is called before the first frame update
    void Start()
    {
        // Import rigidbody component from Player's Ship
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get Player Input
        mousePos = Input.mousePosition;
    }

    // FixedUpdate is called every 0.02 seconds, is frame independent
    private void FixedUpdate()
    {
        // Getting properties from ShipStats.cs
        // TODO: sarebbe bello spostare questi in una funzione che si attivi solo se cambiano
        torqueThrust = GetComponent<ShipStats>().shipProperties.angularThrust;
        angularDrag = GetComponent<ShipStats>().shipProperties.angularDrag;

        // Set Ship physical properties
        // TODO: sarebbe bello spostare questi in una funzione che si attivi solo se cambiano
        rb.angularDrag = angularDrag;

        // getting mouse and Ship direction vectors
        mouseDir = getMouseDirection(mousePos);
        shipDir = getShipDirection();

        // computing the angle and direction sign between mouse and ship direction vectors
        dirAngle = Mathf.Abs(Vector2.Angle(mouseDir, shipDir));
        dirSign = Vector3.Cross(mouseDir, shipDir).z;

        rb.transform.up = mouseDir;

        // applying torque
        rb.AddTorque(torqueThrust * dirSign);
        rb.AddTorque(-torqueThrust * dirSign * dirAngle / 180);
    }

    // function which returns a vector from Ship to mouse position 
    Vector2 getMouseDirection(Vector3 mousePosition)
    {
        Vector2 mouseDirection;

        // retrieve mouse coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // create vector from the Ship to the mouse cursor
        mouseDirection.x = mousePosition.x - rb.transform.position.x;
        mouseDirection.y = mousePosition.y - rb.transform.position.y;

        return mouseDirection.normalized;
    }

    // function which returns a vector pointing the Ship direction
    Vector2 getShipDirection()
    {
        Vector2 shipDirection;
        shipDirection = rb.transform.up;
        return shipDirection.normalized;
    }
}
