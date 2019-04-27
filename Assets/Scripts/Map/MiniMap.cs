using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Target;
    public Vector3 thePosition;
    public float ZoomAmount = 1000000f;
    public float Width = 40;
    public bool IsSegmented;
    public float NumberOfSegments = 16;

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

    public Vector2 TransformPosition(Vector3 position, Vector3 nudge)
    {
        Vector3 offset;
        //Vector3 screenPos = cam.WorldToScreenPoint(Target.position);
        // Debug.Log("target is " + screenPos.x + " pixels from the left");
        if (IsSegmented == true)
        
            offset = RoundPosition(position) - RoundPosition(Target.position) + nudge;
        
        else 
        
            offset = position - Target.position;
            Debug.Log(offset);
            Vector2 newPosition = new Vector2(offset.x, offset.y);
            newPosition *= ZoomAmount;
            return newPosition;
        
        //return newPosition;
    }
    public Vector2 MoveInside(Vector2 point)
    {
        Rect mapRect = GetComponent<RectTransform>().rect;
        point = Vector2.Max(point, mapRect.min);
        point = Vector2.Min(point, mapRect.max);
        return point;
    }
    public Vector3 RoundPosition(Vector3 position)
    {
        float segmentWidth = Width / NumberOfSegments;
        position.x = Mathf.Floor(position.x / segmentWidth) * segmentWidth;
        position.y = Mathf.Floor(position.y / segmentWidth) * segmentWidth;
        return position;
    }
}  
