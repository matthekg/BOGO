using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductInfo : MonoBehaviour
{
    public Product product;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text priceText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = product.name;
        descriptionText.text = product.description;

        artworkImage.sprite = product.art;

        priceText.text = "$" + product.price.ToString();
    }

}
