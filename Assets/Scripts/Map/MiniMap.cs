using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Target;
    public Vector3 thePosition;
    //private Transform player;
    //public Canvas Canvas;
    //Vector3 offset = Vector3.zero;
    //public Camera cam;
    //ivate float offx = 435.1f;
    //ivate float offy = 243.3f;
    void Start()
    {
     //   thePosition = transform.TransformPoint(0,0,0);
       // cam = GetComponent<Camera>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //offset = transform.position - worldToUISpace(Canvas, Target.transform.position);
    }

    public Vector2 TransformPosition(Vector3 position)
    {
        //Vector3 screenPos = cam.WorldToScreenPoint(Target.position);
       // Debug.Log("target is " + screenPos.x + " pixels from the left");

        Vector3 offset = position - Target.position ;
        Debug.Log(offset);
        Vector2 newPosition = new Vector2(-offset.x, -offset.y);
        return newPosition;
    }
}  
