using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coupon", menuName = "Coupon")]
public class Coupon : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite art;

    public bool mustBePlacedOnItem = false;

    [Header("Abilities")]
    public float discount = 0;
    public float percentDiscount = 0;
    public float setAmount = 0;
    public float bogo = 0;




    public void Print()
    {
        Debug.Log(name + ": " + description);
    }
}
