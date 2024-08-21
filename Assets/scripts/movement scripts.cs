using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using JetBrains.Annotations;

public class movementscripts : MonoBehaviour
{
    Vector2 movementInput;
    public  float movementSpeed = 0.1f;

    public float gravity = 9.8f;
    public float jumpspeed = 20f;
    public float verticalspeed = 0;
    public void IAmovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        
    }

    public void IAjump(InputAction.CallbackContext context)
    {
        if(context.started==true)
        {
            Debug.Log("Started");
        }
        if(context.performed == true)
        {
            Debug.Log("performed");
        }
        if (context.canceled == true)
        {
            Debug.Log("canceled");
        }
    }
    void Start()
    {
       
    }
    void Update()
    {
        if (GroundCheck() == true)
        {
            verticalspeed = 0;
        }

        else
        {
            verticalspeed = (verticalspeed - gravity) * Time.deltaTime;
        }


        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, verticalspeed, movementInput.y*movementSpeed * Time.deltaTime);
    }
   
    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1);
    }

   




}
