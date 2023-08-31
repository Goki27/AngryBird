using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour


{
    [SerializeField] float maxDragDistance = 4;
    [SerializeField]     float launchPower = 150;
    LineRenderer lineRenderer;
    Vector3 StartPosition;



    private void Start()
    {
    
      lineRenderer = GetComponent<LineRenderer>();
      lineRenderer.SetPosition(0,transform.position);
        StartPosition = transform.position;
        lineRenderer.SetPosition(1,transform.position);
    }


     void OnMouseUp()
    {
        
        Vector3 directionMagnitude=StartPosition-transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionMagnitude*launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void OnMouseDrag()
    {
        Vector3 destination=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = 0;

        if(Vector2.Distance(destination, StartPosition) > maxDragDistance)
        transform.position = destination;
        destination=Vector3.MoveTowards(StartPosition, destination,maxDragDistance);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
