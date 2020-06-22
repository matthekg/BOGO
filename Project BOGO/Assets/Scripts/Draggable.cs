using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnToMe = null;
    public Transform placeholderParent = null;
    GameObject placeholder = null;
    public enum Slot { PRODUCT, COUPON };
    public Slot typeOfItem = Slot.PRODUCT;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        placeholder = new GameObject();
        placeholder.name = "Empty Spot";
        placeholder.transform.SetParent(transform.parent);
        placeholder.AddComponent<RectTransform>();
        placeholder.GetComponent<RectTransform>().sizeDelta = new Vector2(125, 200);
        LayoutElement layel = placeholder.AddComponent<LayoutElement>();
        layel.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
        layel.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
        layel.flexibleHeight = 0;
        layel.flexibleWidth = 0;

        placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        returnToMe = transform.parent;
        placeholderParent = returnToMe;

        transform.SetParent( transform.root );

        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        transform.position = eventData.position;

        if(placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;
        for(int i = 0; i < placeholderParent.childCount; ++i)
        {
            if(transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    --newSiblingIndex;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        transform.SetParent(returnToMe);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
