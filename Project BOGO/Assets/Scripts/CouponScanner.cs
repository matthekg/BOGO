using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouponScanner : MonoBehaviour
{
    public void scanNewCoupon()
    {
        GameObject newCoupon = transform.GetChild(0).gameObject;
        if( newCoupon.GetComponent<CouponInfo>() != null )
        {
            newCoupon.GetComponent<CouponAbstract>().ScanMe();
        }
        
    }

    public void attachNewCoupon( CouponInfo c )
    {
        c.transform.SetParent(transform);
        scanNewCoupon();
    }
}
