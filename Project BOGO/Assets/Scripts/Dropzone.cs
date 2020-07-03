using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int cap;
    public bool StartOffDisabled;

    private void Awake()
    {
        if(StartOffDisabled)
            gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
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
        int productCount = transform.childCount;
        for( int i = 0; i < productCount; ++i )
        {
            if (!transform.GetChild(i).CompareTag("Product"))
                --productCount;
        }
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if( d != null && productCount < cap)
        {
            d.returnToMe = transform;
        }
    }
}
