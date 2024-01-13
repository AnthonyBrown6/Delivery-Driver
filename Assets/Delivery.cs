using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColour = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColour = new Color32(1, 1, 1, 1);

    bool hasPackage;
    [SerializeField] float packageDestroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // A Collision occurs when an object has a Collider attached to it. 
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Oops! You have crashed");
    }
    
    // A trigger occurs when an Object has a Collider attached to it but the isTrigger is true. This means anything with a Rigid body can move through it.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("You have picked up a package.");            
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Destroy(collision.gameObject, packageDestroyDelay);
        }
        else if (collision.tag == "Customer")
        {
            if (hasPackage) 
            {
                Debug.Log("Package Delivered!");
                spriteRenderer.color = noPackageColour;
                hasPackage = false;
            }
            else
            {
                Debug.Log("You don't have the package!");
            }
        }
    }
}
