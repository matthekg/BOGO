using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public bool clickable = true;
    private UIManager ui;
    private CouponScanner scanner;

    private void Awake()
    {
        ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        scanner = GetComponentInChildren<CouponScanner>();

    }
    public void OnPointerClick( PointerEventData eventData )
    {
        if( clickable )
        {
            if( ui.applyingNewCoupon )
            {
                ui.chosenTarget = GetComponent<ProductInfo>();
                ui.TurnOffHelperPanel();
                ui.clickDone = true;
            }
            else
            {
                print("view");
                // put view product stuff here
            }
        }
    }
}
