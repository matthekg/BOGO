using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CouponAbstract : MonoBehaviour
{
    public abstract void ScanMe();
    public abstract void UndoMe( ProductInfo target );
}
