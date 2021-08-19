using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour, IInteractable
{
    public bool pressed = false;
    public string text = "";
    public GameObject objectToTrigger = null;
    private Animator animator;
    private Text textObj;

    public bool Interact()
    {
        //Call the next item
        if (objectToTrigger != null)
            objectToTrigger.GetComponent<IInteractable>().Interact();

        return pressed = !pressed;

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        textObj = GetComponentInChildren<Text>();
        textObj.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed)
        {
            animator.SetBool("pressed", true);
        }
        else
        {
            animator.SetBool("pressed", false);
        }
        textObj.text = text;
    }
}
