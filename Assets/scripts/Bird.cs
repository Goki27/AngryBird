using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
    

{
    public float launchPower = 5;
    Vector3 StartPosition;



    private void Start()
    {
        StartPosition = transform.position;
    }


     void OnMouseUp()
    {
        
        Vector3 directionMagnitude=StartPosition-transform.position;
        GetComponent<Rigidbody>().AddForce(directionMagnitude*launchPower);
    }

    void OnMouseDrag()
    {
        Vector3 destination=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = 0;
        transform.position = destination;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
