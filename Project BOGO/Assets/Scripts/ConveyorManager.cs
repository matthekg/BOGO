using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Transactions;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    private List<GameObject> conveyorBelt;
    public GameObject conveyorSpot;
    private int conveyorLength = 6;
    private int spaceBetweenSpots = 3;

    // Create a list of conveyor spots and instantiate a line of them
    void Awake()
    {
        conveyorBelt = new List<GameObject>();
        for( int i = 0; i < conveyorLength; ++i )
        {
            GameObject currentSpot = Instantiate(conveyorSpot, transform.position, Quaternion.identity);
            conveyorBelt.Add(currentSpot);
            currentSpot.name = conveyorSpot.name + " " + i.ToString();
            transform.Translate(new Vector3(-spaceBetweenSpots, 0, 0));
        }
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void endTurn()
    {
        scanFirstItem();
        moveConveyor();
    }

    // Scan the first item on the conveyor belt, subtracting its couponed price from your money
    public void scanFirstItem()
    {
        Conveyor first = conveyorBelt[0].GetComponent<Conveyor>();
        if (first.myProduct)
        {
            print(first.myProduct.GetComponent<Product>().price);
            Destroy(conveyorBelt[0].GetComponent<Conveyor>().myProduct);
            Destroy(conveyorBelt[0].GetComponent<Conveyor>().myCoupon);
        }
    }

    // Move the items on the conveyor belt one to the right
    // It is assumed that scan last item was called just before this, therefore the first spot is empty
    public void moveConveyor()
    {
        for (int i = 0; i < conveyorBelt.Count-1; ++i)
        {
            GameObject current = conveyorBelt[i];
            GameObject left = conveyorBelt[i + 1];

            if(left.GetComponent<Conveyor>().myProduct)
            {
                left.GetComponent<BoxCollider2D>().enabled = false;
                left.GetComponent<Conveyor>().myProduct.GetComponent<Product>().nextConveyor = gameObject;
                left.GetComponent<Conveyor>().myProduct.GetComponent<Product>().conveyorOn = true;
                
                
                // **This version has no movement, the item just jumps to the next spot
                // **It also copies and destroys the original
                //GameObject cpy = Instantiate(left.GetComponent<Conveyor>().myProduct);
                //conveyorBelt[i].GetComponent<Conveyor>().myProduct = cpy;
                //Destroy(conveyorBelt[i + 1].GetComponent<Conveyor>().myProduct);
            }
            if (left.GetComponent<Conveyor>().myCoupon)
            {
                GameObject cpy = Instantiate(left.GetComponent<Conveyor>().myCoupon);
                conveyorBelt[i].GetComponent<Conveyor>().myProduct = cpy;
                Destroy(conveyorBelt[i + 1].GetComponent<Conveyor>().myCoupon);
            }

            // Move the sprite as well
            //conveyorBelt[i].GetComponent<Conveyor>().myProduct.transform.position = current.transform.position;
        }

    }
    
}
