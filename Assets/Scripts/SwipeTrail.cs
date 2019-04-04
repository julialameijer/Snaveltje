using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTrail : MonoBehaviour
{
    [SerializeField]
    private GameObject swipeObject;

    private GameObject thisTrail;
    private Vector3 startPos;
    private Plane objPlane;
    private Ray ray;

    void Start()
    {
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //this.transform.position = Input.mousePosition;
        Vector3 mousePos = Input.mousePosition;
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began|| Input.GetMouseButtonDown(0))
        {
            thisTrail = (GameObject)Instantiate(swipeObject, this.transform.position, Quaternion.identity);        
            float rayDistance;

            if (objPlane.Raycast(ray, out rayDistance))
            {
                startPos = ray.GetPoint(rayDistance);
                //print(mousePos);
                print(Input.mousePosition);
                //print(ray.GetPoint(rayDistance));
                //print(ray);
                //print(rayDistance);
                //print(this.transform.position);
            }   

        }

        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            float rayDistance;

            if (objPlane.Raycast(ray, out rayDistance))
            {
                thisTrail.transform.position = ray.GetPoint(rayDistance);
            }
        }

        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButton(0))
        {
            if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1)
            {
                Destroy(thisTrail);
            }
        }
    }
}

