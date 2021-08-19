using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum eType { TargetObject, TargetScene, TargetExit };
public class Teleporter : MonoBehaviour, IInteractable
{
    public string targetName;
    public eType targetType;
    public bool triggerEnabled;
    private void OnTriggerEnter(Collider other)
    {
        if (triggerEnabled)
        {
            if (targetType == eType.TargetObject)
            {
                var obj = GameObject.Find(targetName);
                other.transform.SetPositionAndRotation(obj.transform.position, obj.transform.rotation);
            }
            else if (targetType == eType.TargetScene)
            {
                SceneManager.LoadScene(targetName);
            }
            else if(targetType == eType.TargetExit)
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            }
        }
        else
        {
            Debug.LogWarning(string.Format("{0} is not enabled!", this.name));
        }
    }
    public bool Interact()
    {
        return triggerEnabled = true;
    }
}