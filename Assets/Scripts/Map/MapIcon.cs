using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIcon : MonoBehaviour {

    public Transform Target;
    //private Transform player;
    public MiniMap map;
    public RectTransform myRectTransform;
    public float SegmentOffset;
    //public Vector2 newPosition;

    public bool KeepWithinBoundary = true;



	// Use this for initialization
	void Start () {
        map = GetComponentInParent<MiniMap>();
     
        myRectTransform = GetComponent<RectTransform>();
       //omponent().anchoredPosition;
        //   player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 offset = map.TransformPosition(Target.position,new Vector3(SegmentOffset, SegmentOffset, 0));
        //transform.position = map.TransformPosition(Target.position, new Vector3(SegmentOffset, SegmentOffset, 0));
        // Vector2 newPosition = Target.position + offset;
        //Vector2 newPosition =  offset;
         
        Vector2 newPosition = map.TransformPosition(Target.position, new Vector3(SegmentOffset, SegmentOffset, 0));
        //Vector2 newPosition = Target.position;
        // Vector2 newPosition = camera.worldtoscrreen.TransformPosition(Target.position);
        // camera.worldtoscreenpoint
        if (KeepWithinBoundary) 
            newPosition = map.MoveInside(newPosition);
            
         myRectTransform.localPosition = newPosition;
    }
    }
