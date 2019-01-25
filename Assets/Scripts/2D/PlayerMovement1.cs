using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float jumpForce = 50f;
    [SerializeField] private float walkSpeed = 100f;
    [SerializeField] private float runSpeed= 250f;
    [SerializeField] private float gravity = 5f;

    internal bool airborne;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(float horizontalMovementValue, bool jump,bool run)
    {
        if (jump&&!airborne)
        {
            rb.AddForce(0,jumpForce,0);
            airborne = true;
        }

        if (airborne)
        {
            rb.AddForce(new Vector3(0,-gravity,0));
        }

        if (run)
        {
            rb.velocity = new Vector3(horizontalMovementValue*Time.fixedDeltaTime*runSpeed, rb.velocity.y,0);
            // play different animator
        }
        else
        {
            rb.velocity = new Vector3(horizontalMovementValue*Time.fixedDeltaTime*walkSpeed, rb.velocity.y,0);            
        }
        
        
    }
}
