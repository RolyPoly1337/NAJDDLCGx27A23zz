using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOpacityMap : MonoBehaviour
{
    public GameObject UItoDisable;
    public bool Toggled = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && Toggled == false)
        {

            UItoDisable.GetComponent<CanvasGroup>().alpha = 1;
            Toggled = true;

        }
        else if (Input.GetKeyDown(KeyCode.M) && Toggled == true) 
        {
            Toggled = false;
            UItoDisable.GetComponent<CanvasGroup>().alpha = 0;


        }
    }

}