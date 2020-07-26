using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouponScanner : MonoBehaviour
{
    public void scanNewCoupon()
    {
        GameObject newCoupon = transform.GetChild(0).gameObject;
        print(newCoupon);
        if( newCoupon.GetComponent<CouponInfo>() != null )
        {
            print("SCAN!");
            newCoupon.GetComponent<CouponAbstract>().ScanMe();
        }
        
    }
}
