using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discount : CouponAbstract
{
    public void ApplyDiscount( ProductInfo target )
    {
        target.currentPrice -= GetComponent<CouponInfo>().discount;
        target.UpdateStatsUI();
    }

    public override void ScanMe()
    {
        ApplyDiscount(transform.parent.parent.GetComponent<ProductInfo>());
    }
}
