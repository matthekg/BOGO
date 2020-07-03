using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnToMe = null;
    public Transform placeholderParent = null;
    public Sprite placeholderSprite = null;
    GameObject placeholder = null;
    public enum Slot { PRODUCT, COUPON };
    public Slot typeOfItem = Slot.PRODUCT;
    private bool setOnConveyor = false;



    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = new GameObject();
        placeholder.name = "Drop Here";
        placeholder.transform.SetParent(transform.parent);
        placeholder.AddComponent<RectTransform>();
        placeholder.AddComponent<Image>();
        placeholder.GetComponent<Image>().sprite = placeholderSprite;
        placeholder.GetComponent<Image>().color = Color.yellow;
        placeholder.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
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
        transform.position = eventData.position;

        // If we drag over an outside object that isn't where we came from
        if (placeholder.transform.parent != placeholderParent)
        {
            // If that object is a dropzone that isn't full
            if (placeholderParent.transform.GetComponent<Dropzone>() != null &&
                placeholderParent.transform.childCount < placeholderParent.transform.GetComponent<Dropzone>().cap)
            {
                // Show drop squre
                placeholder.transform.SetParent(placeholderParent);
            }
        }
        else
        {
            // Show the drop square in the right place
            Dropzone d = placeholderParent.GetComponent<Dropzone>();
            if ( d !=  null )
            {
                int newSiblingIndex = placeholderParent.childCount;
                for (int i = 0; i < placeholderParent.childCount; ++i)
                {
                    if (transform.position.x < placeholderParent.GetChild(i).position.x &&
                        transform.position.y < placeholderParent.GetChild(i).position.y)
                    {
                        newSiblingIndex = i;

                        if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                            --newSiblingIndex;

                        break;
                    }
                }
                placeholder.transform.SetSiblingIndex(newSiblingIndex);
            }

        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (setOnConveyor)
            return;

        transform.SetParent(returnToMe);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);

        GameObject lane = GameObject.Find("CheckoutLane");
        if ( typeOfItem == Slot.PRODUCT)
        {
            if (lane.GetComponent<ConveyorLogic>() != null)
            {
                lane.GetComponent<ConveyorLogic>().countProducts();
            }
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
