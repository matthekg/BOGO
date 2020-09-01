using UnityEngine;
using UnityEngine.UI;

public class CouponInfo : MonoBehaviour
{
    public Coupon couponLogic;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public float discount;
    public float percDiscount;
    public float setPrice;
    public float bogo;

    public CouponScanner last = null;

    private void Awake()
    {
        nameText.text = couponLogic.name;
        descriptionText.text = couponLogic.description;

        artworkImage.sprite = couponLogic.art;



        // Turn this generic coupon into its specified coupon
        discount = couponLogic.discount;
        percDiscount = couponLogic.percentDiscount;
        setPrice = couponLogic.setAmount;
        bogo = couponLogic.bogo;
        ApplyComponents();
    }

    private void ApplyComponents()
    {
        if (discount != 0 && !this.gameObject.GetComponent<Discount>() )
        {
            this.gameObject.AddComponent<Discount>();
        }

        if (percDiscount != 0 && !this.gameObject.GetComponent<PercentDiscount>())
        {
            this.gameObject.AddComponent<PercentDiscount>();
        }

        if (setPrice != -1 && !this.gameObject.GetComponent<SetPrice>())
        {
            this.gameObject.AddComponent<SetPrice>();
        }

        if (bogo != 0 && !this.gameObject.GetComponent<BOGO>())
        {
            this.gameObject.AddComponent<BOGO>();
        }

    }


}
