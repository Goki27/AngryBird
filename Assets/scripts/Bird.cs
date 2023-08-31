using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
       lineRenderer.enabled = false;
    }


     void OnMouseUp()
    {
        
        Vector3 directionMagnitude=StartPosition-transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionMagnitude*launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        lineRenderer.enabled = false;   
    }

    void OnMouseDrag()
    {
        Vector3 destination=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = 0;

        if(Vector2.Distance(destination, StartPosition) > maxDragDistance)
        transform.position = destination;
        destination=Vector3.MoveTowards(StartPosition, destination,maxDragDistance);
        lineRenderer.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (FindAnyObjectByType<Enemy>(FindObjectsInactive.Exclude) == null)
        {
            var levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(levelToLoad);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Invoke(nameof(RloadLevel),5);
    }
    private void RloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
