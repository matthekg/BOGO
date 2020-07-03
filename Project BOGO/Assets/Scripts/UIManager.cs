using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text money;
    private int m = 0;

    private void Awake()
    {
        money = GameObject.Find("CheckoutTotal").GetComponent<Text>();
        SetMoneyUI(0);
    }

    public void SetMoneyUI( int t )
    {
        m = t;
        money.text = "TOTAL    " + t.ToString("N2");
        //money.text.Replace("$", "");
    }

    public void AddMoney( int t )
    {
        SetMoneyUI(m + t);
    }
}
