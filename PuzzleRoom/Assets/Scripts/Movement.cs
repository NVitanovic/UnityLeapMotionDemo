using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = 1.0f;
    public bool move = true;
    public bool crouch = true;
    public Camera cam;
    public GameObject hands;
    private float originalHeight;
    private float crouchHeight;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
        crouchHeight = originalHeight / 4;
    }
    void Update()
    {
        //Check for angle for movement or crouch
        if(cam.transform.localEulerAngles.x > 40 && cam.transform.localEulerAngles.x < 60)
        {
            move = true;
            crouch = false;
        }
        else if(cam.transform.localEulerAngles.x > 75 && cam.transform.localEulerAngles.x < 85)
        {
            crouch = true;
        }
        else
        {
            move = false;
            crouch = false;
        }

        // Actual movement
        if (move)
        {
            Vector3 moveDistance = Camera.main.transform.forward;
            controller.SimpleMove(moveDistance * playerSpeed);
        }
        else if(crouch)
        {
            controller.height = crouchHeight;
            controller.SimpleMove(Camera.main.transform.forward);
        }
        else
        {
            controller.height = originalHeight;
        }
    }
}
