using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using JetBrains.Annotations;

public class movementscripts : MonoBehaviour
{
    Vector2 movementInput;
    public  float movementSpeed = 0.1f;
    public void IAmovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        
    }
    void Start()
    {
       
    }
    void Update()
    {
       
        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, 0, movementInput.y*movementSpeed * Time.deltaTime);
    }
   
    
}
