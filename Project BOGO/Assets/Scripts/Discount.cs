using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Discount : CouponAbstract
{
    public void ApplyDiscount(ProductInfo target, bool reverse=false )
    {
        if (reverse)
            target.currentPrice += GetComponent<CouponInfo>().discount;
        else
            target.currentPrice -= GetComponent<CouponInfo>().discount;

        target.UpdateStatsUI();
    }

    public override void ScanMe()
    {
        ApplyDiscount(GetComponentInParent<ProductInfo>());
    }

    public override void UndoMe( ProductInfo target )
    {
        ApplyDiscount(target, true);
    }
}
