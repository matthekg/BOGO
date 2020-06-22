using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnToMe = null;

    public enum Slot { PRODUCT, COUPON };
    public Slot typeOfItem = Slot.PRODUCT;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        transform.SetParent( transform.root );

        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        transform.position = eventData.position;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        transform.SetParent(returnToMe);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
