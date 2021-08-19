using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Camera playerCamera;
    private float totalLookingTime;
    private GameObject lastObject;
    private Color previousObjectColor;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        lastObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        RaycastHit hit;
        // Check raycast hit in distance of 1.5m in game units and Layer is Interactable
        if (Physics.Raycast(ray, out hit, 1.5f) && hit.collider.gameObject.layer == 8)
        {
            print("I'm looking at " + hit.transform.name);
            var objectRenderer = hit.collider.gameObject.GetComponent<Renderer>();

            if (lastObject != hit.collider.gameObject)
            {
                totalLookingTime = 0;

                if (lastObject != null)
                    lastObject.GetComponent<Renderer>().material.color = previousObjectColor;

                // Get the new object color once
                previousObjectColor = hit.collider.gameObject.GetComponent<Renderer>().material.color;
            }
            else
            {
                totalLookingTime += Time.deltaTime;
            }

            // if the player looks into the object for more than 5 seconds
            // trigger the interactable event in the object
            if(totalLookingTime > 3)
            {
                lastObject.GetComponent<Renderer>().material.color = previousObjectColor;
                hit.collider.gameObject.GetComponent<IInteractable>().Interact();
                totalLookingTime = 0;
            }
            else
            {
                //highlight the object
                objectRenderer.material.color = Color.yellow;
            }

            // save the last object that the player was looking at for comparison
            lastObject = hit.collider.gameObject;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.green);
        }
        else
        {
            totalLookingTime = 0;
            print("I'm looking at nothing!");
            if(lastObject != null)
                lastObject.GetComponent<Renderer>().material.color = previousObjectColor;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.red);
        }
    }
}
