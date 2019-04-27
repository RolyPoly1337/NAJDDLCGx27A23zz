using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blip : MonoBehaviour {

    public Transform Target;
    //private Transform player;
    MiniMap map;
    RectTransform myRectTransform;
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
        Vector2 newPosition = Target.position;
        // Vector2 newPosition = camera.worldtoscrreen.TransformPosition(Target.position);
        // camera.worldtoscreenpoint
         myRectTransform.localPosition = newPosition;
    }
    }
