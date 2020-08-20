using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOGO : CouponAbstract
{
    /* I think I'll make bogo work by giving the first product a "BO" half coupon,
     * and it's duplicate a "GO" coupon that has the discount
     * 
     * UI manager has a copy of all available coupons as its children. Use this to decide the coupon
     * that BOGO creates in GiveDuplicateCoupon()
    */

    private float bogoPercent;
    private string popupText = "Choose another product like me to get the discount";
    private UIManager ui;
    private Minimize cart;
    public bool waiting = false;

    private void Awake()
    {
        cart = GameObject.Find("Cart").GetComponent<Minimize>();
        ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    IEnumerator PromptForDuplicate( Action giveCoup)
    {
        ui.NewHelperPanel(popupText);
        cart.ToggleOpen();
        GameObject[] allProducts = GameObject.FindGameObjectsWithTag("Product");
        string myName = this.GetComponentInParent<ProductInfo>().product.name;
        foreach (GameObject p in allProducts)
        {
            string theirName = p.GetComponent<ProductInfo>().product.name;

            // Only allow duplicate products to get the coupon
            p.GetComponent<Clickable>().clickable = (myName == theirName);
        }
        ui.clickDone = false;
        ui.applyingNewCoupon = true;
        ui.floatingCoupon = Instantiate(ui.transform.GetChild(0).GetComponent<CouponInfo>());
        ui.floatingCoupon.GetComponent<Draggable>().shouldntMove = true;

        yield return StartCoroutine(ui.WaitForClick());
        giveCoup();
    }

    private void GiveDuplicateCoupon()
    {
        ui.GiveTargetFloatingCoupon();
        ui.applyingNewCoupon = false;
    }

    public override void ScanMe()
    {
        StartCoroutine(PromptForDuplicate( GiveDuplicateCoupon));
    }

    public override void UndoMe(ProductInfo target)
    {
        throw new System.NotImplementedException();
    }
}
