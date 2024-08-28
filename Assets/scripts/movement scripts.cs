using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using JetBrains.Annotations;

public class movementscripts : MonoBehaviour
{
    Vector2 movementInput;
    public float movementSpeed = 0.1f;
    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public float gravity = 9.8f;
    public float jumpspeed = 20f;
    public float verticalspeed = 0;
    public void IAmovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

    }

    public void IAjump(InputAction.CallbackContext context)
    {
        if (context.started == true && GroundCheck())
        {
            verticalspeed = jumpspeed;
        }
    }

    public void IAInteract(InputAction.CallbackContext context)
    {

    }
    void Start()
    {
       
    }
    void Update()
    {
        if (GroundCheck() == true && verticalspeed <= 0)
        {
            verticalspeed = 0;
        }

        else
        {
            verticalspeed = verticalspeed - gravity * Time.deltaTime;
        }


        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, verticalspeed * Time.deltaTime, movementInput.y*movementSpeed * Time.deltaTime);
    }
   
    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1.1f);

       public void InteractionRaycast()
        {
        Vector3 myposition = transform.position;
            Vector3 Cameradirection = playerCamera.transform.forward;

            Ray Interactionray = new Ray(transform.position,Cameradirection);

            RaycastHit targetInfo;

            Physics.Raycast(Interactionray, out targetInfo, 5f);
        }
    }

   




}
