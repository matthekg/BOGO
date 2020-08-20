using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public bool clickable = false;
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
            CouponInfo newCoupon = ui.floatingCoupon;
            scanner.attachNewCoupon(newCoupon);
            ui.TurnOffHelperPanel();
        }
    }
}
