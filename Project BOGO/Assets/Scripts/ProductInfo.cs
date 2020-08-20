using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class ProductInfo : MonoBehaviour
{
    public Product product;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text priceText;

    [Space(10)]
    [Header("Product Stats")]
    private float basePrice;

    public float currentPrice;

    public Transform couponScanner;
    private GameObject couponIndic;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = product.name;
        descriptionText.text = product.description;

        artworkImage.sprite = product.art;

        priceText.text = "$" + product.price.ToString();
        basePrice = currentPrice = product.price;

        couponScanner = transform.GetChild(2);
        couponIndic = transform.GetChild(transform.childCount - 1).gameObject;
        couponIndic.SetActive(false);
    }
    public void UpdateStatsUI()
    {
        priceText.text = "$" + currentPrice.ToString();// ("00.00");
    }

    public void SetUIToConveyorMode()
    {
        SetCouponIndicator();
        couponScanner.gameObject.SetActive(true);
        
    }

    public void SetUIToCartMode()
    {
        SetCouponIndicator();
        couponScanner.gameObject.SetActive(false);
    }

    public void SetCouponIndicator()
    {
        Transform c = transform.GetChild(2);
        if (c.childCount > 0 && transform.parent.name == "Cart")
            couponIndic.SetActive(true);
        else
            couponIndic.SetActive(false);
    }    

}
