using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text money;
    private float m = 0;

    private void Awake()
    {
        money = GameObject.Find("CheckoutTotal").GetComponent<Text>();
        SetMoneyUI(0);
    }

    public void SetMoneyUI( float t )
    {
        m = t;
        money.text = t.ToString("N2");
        //money.text.Replace("$", "");
    }

    public void AddMoney( float t )
    {
        SetMoneyUI(m + t);
    }
}
