using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public Animator animator;
    public bool open;
    public bool triggerEnabled = true;
    public string text;
    private Text textMesh;
    void Start()
    {
        textMesh = GetComponentInChildren<Text>();
        textMesh.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if(open == true)
        {
            animator.SetBool("Closed", false);
        }
        else
        {
            animator.SetBool("Closed", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(triggerEnabled)
            open = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(triggerEnabled)
            open = false;
    }

    public bool Interact()
    {
        return open = !open;
    }
    public void Open()
    {
        open = true;
    }
    public void Close()
    {
        open = false;
    }
}
