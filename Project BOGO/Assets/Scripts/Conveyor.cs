using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject myProduct = null;
    public GameObject myCoupon = null;
    public Color defaultColor = Color.black;
    public Color hoverColor = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (myProduct != null)
            GetComponent<SpriteRenderer>().color = defaultColor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = hoverColor;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = defaultColor;
    }



}
