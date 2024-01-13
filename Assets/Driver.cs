using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float fastSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float acceleratorAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, acceleratorAmount, 0);
    }

    // A Collision occurs when an object has a Collider attached to it. 
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

    // A trigger occurs when an Object has a Collider attached to it but the isTrigger is true. This means anything with a Rigid body can move through it.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            moveSpeed = fastSpeed;
        }
    }
}
