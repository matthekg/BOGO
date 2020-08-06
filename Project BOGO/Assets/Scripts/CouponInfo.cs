using UnityEngine;
using UnityEngine.UI;

public class CouponInfo : MonoBehaviour
{
    public Coupon coupon;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public float discount;
    public float percDiscount;

    private void Awake()
    {
        nameText.text = coupon.name;
        descriptionText.text = coupon.description;

        artworkImage.sprite = coupon.art;

        discount = coupon.discount;
        percDiscount = coupon.percentDiscount;

        if (discount != 0)
        {
            this.gameObject.AddComponent<Discount>();
        }

        if (percDiscount != 0)
        {
            this.gameObject.AddComponent<PercentDiscount>();
        }
            
    }


}
