using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public string productName = null;
    public float price = 0.0f;
    public Sprite image = null;

    private float moveSpeed = 5f;
    public bool conveyorOn = false;
    public GameObject nextConveyor = null;
    

    // Start is called before the first frame update
    void Start()
    {
        name = productName;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        if (conveyorOn)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nextConveyor.transform.position, -step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Conveyor"))
        {
            conveyorOn = false;
            nextConveyor = null;
        }
    }
}
