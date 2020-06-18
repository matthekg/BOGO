using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isProduct; // else is coupon
    public bool movable = true;
    public GameObject closestConveyor = null;
    int convCount = 0;
    Touch t;

    // Update is called once per frame
    void Update()
    {
        if( Input.touchCount > 0 && movable)
        {
            t = Input.GetTouch(0);
            Vector3 tPos = Camera.main.ScreenToWorldPoint(t.position);
            tPos.z = 0;
            transform.position = tPos;
        }

        if( t.phase == TouchPhase.Ended )
        {
            if (closestConveyor != null)
            {
                movable = false;
                transform.position = closestConveyor.transform.position;
                if (isProduct)
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
