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

        if(Input.mousePosition.x > 295.6 && Input.mousePosition.x < 1618 && Input.mousePosition.y < 800)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            {
                thisTrail = (GameObject)Instantiate(swipeObject, this.transform.position, Quaternion.identity);
                float rayDistance;

                if (objPlane.Raycast(ray, out rayDistance))
                {
                    startPos = ray.GetPoint(rayDistance);
                   
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

    public void changeColor(string color)
    {
        TrailRenderer trailRenderer = thisTrail.GetComponent<TrailRenderer>();
        Material white = trailRenderer.materials[0];
        Material black = trailRenderer.materials[1];
        Material red = trailRenderer.materials[2];
        Material bordeaux = trailRenderer.materials[3];
        Material orange = trailRenderer.materials[4];
        Material yellow = trailRenderer.materials[5];
        Material green = trailRenderer.materials[6];
        Material blue = trailRenderer.materials[7];
        Material darkblue = trailRenderer.materials[8];
        Material purple = trailRenderer.materials[9];
        Material pink = trailRenderer.materials[10];

        switch (color)
        {
            case "white":
                trailRenderer.material.SetColor("_Color", white.color);
                break;
            case "black":
                trailRenderer.material.SetColor("_Color", black.color);
                break;
            case "red":
                trailRenderer.material.SetColor("_Color", red.color);
                break;
            case "bordeaux":
                trailRenderer.material.SetColor("_Color", bordeaux.color);
                break;
            case "orange":
                trailRenderer.material.SetColor("_Color", orange.color);
                break;
            case "yellow":
                trailRenderer.material.SetColor("_Color", yellow.color);
                break;
            case "green":
                trailRenderer.material.SetColor("_Color", green.color);
                break;
            case "blue":
                trailRenderer.material.SetColor("_Color", blue.color);
                break;
            case "darkblue":
                trailRenderer.material.SetColor("_Color", darkblue.color);
                break;
            case "purple":
                trailRenderer.material.SetColor("_Color", purple.color);
                break;
            case "pink":
                trailRenderer.material.SetColor("_Color", pink.color);
                break;

        }
        
    }

        
}

