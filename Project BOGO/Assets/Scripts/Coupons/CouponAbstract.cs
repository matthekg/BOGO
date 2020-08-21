using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CouponAbstract : MonoBehaviour
{
    public int size;
    public abstract void ScanMe();
    public abstract void UndoMe( ProductInfo target );
}
