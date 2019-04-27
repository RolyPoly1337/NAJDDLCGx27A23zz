using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOpacityMap : MonoBehaviour
{
    public GameObject UItoDisable;
    public bool Toggled = false;
    void Update()
    {
        if ((Input.GetKey(KeyCode.M)))
        {

            UItoDisable.GetComponent<CanvasGroup>().alpha = 1;
            Toggled = true;

        }
        else 
        {
            Toggled = false;
            UItoDisable.GetComponent<CanvasGroup>().alpha = 0;


        }
    }

}