using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentDiscount : CouponAbstract
{
    private float amountToSubtract = 0;
    private float discountAmount;

    private void CalculateAmount()
    {
        CouponInfo c = GetComponent<CouponInfo>();
        ProductInfo p = GetComponentInParent<ProductInfo>();
        discountAmount = p.currentPrice * c.percDiscount / 100;
    }

    public void ApplyDiscount(ProductInfo target, bool reverse = false)
    {
        if (reverse)
            target.currentPrice += discountAmount;
        else
            target.currentPrice -= discountAmount;

        target.UpdateStatsUI();
    }

    public override void ScanMe()
    {
        CalculateAmount();
        ApplyDiscount(GetComponentInParent<ProductInfo>());
    }

    public override void UndoMe(ProductInfo target)
    {
        ApplyDiscount(target, true);
    }
}
