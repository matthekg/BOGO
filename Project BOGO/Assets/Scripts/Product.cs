using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Product")]
public class Product : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite art;

    public float price;

    public void Print()
    {
        Debug.Log(name + ": " + description + "[$" + price + "]");
    }

}
