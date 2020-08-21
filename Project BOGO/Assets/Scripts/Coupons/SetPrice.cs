using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPrice : CouponAbstract
{
    private float newAmount;
    public float oldAmount;

    private void SetPriceOf( ProductInfo target, bool reverse = false )
    {
        newAmount = GetComponent<CouponInfo>().setPrice;

        if (reverse)
            target.currentPrice = oldAmount;
        else
            target.currentPrice = newAmount;

        target.UpdateStatsUI();
    }

    public override void ScanMe()
    {
        ProductInfo p = GetComponentInParent<ProductInfo>();
        oldAmount = GetComponentInParent<ProductInfo>().currentPrice;
        SetPriceOf(p);
    }

    public override void UndoMe(ProductInfo target)
    {
        SetPriceOf(target, true);
    }
}
