using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject objectToTrigger = null;
    public bool pressed = false;
    public bool triggerEnabled = true;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
    }
    private void OnTriggerExit(Collider other)
    {
        if (triggerEnabled)
        {
            animator.SetBool("pressed", false);
            pressed = false;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerEnabled)
        {
            animator.SetBool("pressed", true);

            if (objectToTrigger != null)
                objectToTrigger.GetComponent<IInteractable>().Interact();
            pressed = true;
        }
            
    }
}
