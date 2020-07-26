using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int cap;
    public bool StartOffDisabled;
    public enum Slot { PRODUCT, COUPON };
    public Slot AcceptedType = Slot.PRODUCT;


    private void Start()
    {
        if(StartOffDisabled)
            gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && (int)d.typeOfItem == (int)AcceptedType)
            d.placeholderParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == transform)
            d.placeholderParent = d.returnToMe;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Make sure we aren't at [cap]acity
        int productCount = transform.childCount;
        for( int i = 0; i < productCount; ++i )
        {
            if (!transform.GetChild(i).CompareTag("Product"))
                --productCount;
        }

        // Set ourselves as the draggable's parent
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if( d != null && productCount < cap && (int)d.typeOfItem == (int)AcceptedType)
        {
            d.returnToMe = transform;
        }
    }
}
