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
    public Slot typeOfItem;
    public bool shouldntMove = false;
    GameObject lane;

    public void Awake()
    {
        lane = GameObject.Find("CheckoutLane");
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (shouldntMove)
            return;

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
        if (shouldntMove)
            return;

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
                if (typeOfItem == Slot.COUPON)
                {
                    newSiblingIndex = 0;
                }
                else
                {
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

                }
                placeholder.transform.SetSiblingIndex(newSiblingIndex);
            }

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (shouldntMove)
            return;

        transform.SetParent(returnToMe);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);
        

        // If we're dragging a product to the dropzone, turn on it's couponzone.
        if( transform.childCount > 4)
        {
            Transform couponzone = transform.GetChild(2); // Should be the CouponZone
            if (typeOfItem == Slot.PRODUCT && transform.parent.name == "DropArea")
            {
                GetComponent<ProductInfo>().SetUIToConveyorMode();
            }
            else
                GetComponent<ProductInfo>().SetUIToCartMode();
        }

        // If we're dragging a coupon, apply the coupon

        if ( typeOfItem == Slot.COUPON )
        {
            // Set the coupon at the beginning
            transform.SetSiblingIndex(0);
            if( transform.parent.GetComponent<CouponScanner>())
            {
                transform.parent.GetComponent<CouponScanner>().AttachNewCoupon( GetComponent<CouponInfo>() );
            }
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // If we're dragging coupon off of a product, undo the effect once it lands in the coupon pouch
        if (typeOfItem == Slot.COUPON && placeholderParent.name == "CouponPouch")
        {
            GetComponent<CouponAbstract>().UndoMe( GetComponent<CouponInfo>().last.transform.GetComponentInParent<ProductInfo>() );
        }

    }
}
