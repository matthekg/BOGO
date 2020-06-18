using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public string productName = null;
    public float price = 0.0f;
    public Sprite image = null;
    

    // Start is called before the first frame update
    void Start()
    {
        name = productName;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
