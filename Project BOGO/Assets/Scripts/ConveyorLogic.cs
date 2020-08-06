using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorLogic : MonoBehaviour
{
    public UIManager uiManager = null;
    public GameObject empty;
    public GameObject drop;
    public GameObject boughtArea;
    public int productCount = 0;


    public bool getFromDrop()
    {
        if (drop.transform.childCount > 0)
        {
            Transform item = drop.transform.GetChild(0);
            item.SetParent(transform, false);
            item.SetSiblingIndex(0);
            item.GetComponent<Draggable>().shouldntMove = true;
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
        {}
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

        countProducts();
    }


    // Scans the product first in queue, then move it to BoughtItems
    public void Scan()
    {
        GameObject target = transform.GetChild(transform.childCount - 1).gameObject;

        if (target.CompareTag("EmptySpot"))
            Destroy(target);
        else
        {
            ProductInfo p = target.GetComponent<ProductInfo>();
            uiManager.AddMoney( p.currentPrice );
            target.transform.SetParent(boughtArea.transform);
        }
    }
}
