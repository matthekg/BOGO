using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isAProduct; // else is coupon
    private bool draggable = true;
    public GameObject closestConveyor;
    int convCount = 0;
    Touch t;

    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    void Update()
    {
        //We check if we have more than one touch happening.
        //We also check if the first touches phase is Ended (that the finger was lifted)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            //We transform the touch position into word space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);
            }
        }



        if ( t.phase == TouchPhase.Ended )
        {
            if (closestConveyor != null)
            {
                draggable = false;
                transform.position = closestConveyor.transform.position;
                if (isAProduct)
                    closestConveyor.GetComponent<Conveyor>().myProduct = this.gameObject;
                else
                    closestConveyor.GetComponent<Conveyor>().myCoupon = this.gameObject;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Conveyor") )
        {
            closestConveyor = collision.gameObject;
            ++convCount;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.CompareTag("Conveyor"))
        {
            --convCount;
        }
        if ( convCount <= 0 )
        {
            closestConveyor = null;
        }
    }
}
