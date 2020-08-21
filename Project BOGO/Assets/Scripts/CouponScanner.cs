using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CouponScanner : MonoBehaviour
{
    public List<CouponInfo> myCoupons = new List<CouponInfo>();

    public void ScanNewCoupon()
    {
        GameObject newCoupon = transform.GetChild(0).gameObject;
        if( newCoupon.GetComponent<CouponInfo>() != null )
        {
            newCoupon.GetComponent<CouponAbstract>().ScanMe();
        }     
    }

    public void AttachNewCoupon( CouponInfo c )
    {
        c.transform.SetParent(transform);
        c.transform.localScale = new Vector3(1,1,1);
        myCoupons.Add(c);
        c.last = this;
        ScanNewCoupon();
    }
}
