using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorLogic : MonoBehaviour
{
    public UIManager uiManager = null;
    public GameObject empty;
    public GameObject drop;
    public int productCount = 0;


    public bool getFromDrop()
    {
        if (drop.transform.childCount > 0)
        {
            Transform item = drop.transform.GetChild(0);
            item.SetParent(transform, false);
            item.SetSiblingIndex(0);
            return true;
        }
        return false;
    }

    public void countProducts()
    {
        int count = 0;
        for( int i = 0; i < transform.childCount; ++i )
        {
            if (transform.GetChild(i).CompareTag("Product"))
                ++count;
        }
        productCount = count;
    }

    public void MoveConveyor()
    {
        // If there's an item get it
        if( getFromDrop() )
        {

        }
        // Otherwise move the conveyor and put an empty spot
        else
        {
            GameObject e = Instantiate(empty);
            e.transform.SetParent(transform, false);
            e.transform.SetSiblingIndex(0);
        }

        // After moving the conveyor, scan an item if it's available
        if (transform.childCount >= 7)
        {
            Scan();
        }

    }


    // Scans the product first in queue, destroying it
    public void Scan()
    {
        GameObject target = transform.GetChild(transform.childCount - 1).gameObject;

        if (target.CompareTag("EmptySpot"))
            Destroy(target);
        else
        {
            Product p = target.GetComponent<ProductInfo>().product;
            uiManager.AddMoney( p.price );
            Destroy(target);
        }
    }
}
