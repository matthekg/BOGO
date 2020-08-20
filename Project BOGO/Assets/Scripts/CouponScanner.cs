using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouponScanner : MonoBehaviour
{
    /*private void OnEnable()
    {
        int couponCount = transform.childCount;
        for( int i = 0; i < couponCount; ++i )
        {
            
        }
    }*/
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
        ScanNewCoupon();
    }
}
