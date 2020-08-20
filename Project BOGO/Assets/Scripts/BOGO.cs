using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOGO : CouponAbstract
{
    /* I think I'll make bogo work by giving the first product a "BO" half coupon,
    /* and it's duplicate a "GO" coupon that has the discount
    */

    private float bogoPercent;
    private string popupText = "Choose another product like me to get the discount";
    private UIManager ui;

    private void PromptForDuplicate()
    {
        ui.NewHelperPanel(popupText);
    }

    private void GiveDuplicateCoupon()
    {
        ui.floatingCoupon = Instantiate(ui.transform.GetChild(0).GetComponent<CouponInfo>());
        ui.floatingCoupon.GetComponent<Draggable>().shouldntMove = true;

    }

    public override void ScanMe()
    {
        ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        PromptForDuplicate();
        GiveDuplicateCoupon();
    }

    public override void UndoMe(ProductInfo target)
    {
        throw new System.NotImplementedException();
    }
}
