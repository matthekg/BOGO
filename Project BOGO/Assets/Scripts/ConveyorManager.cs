using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    List<GameObject> conveyorBelt = new List<GameObject>();
    public GameObject conveyorSpot;
    public int conveyorLength = 6;
    public int spaceBetweenSpots = 0;

    // Start is called before the first frame update
    void Start()
    {
        for( int i = 0; i < conveyorLength; ++i )
        {
            conveyorBelt.Add(conveyorSpot);
        }

        foreach( GameObject spot in conveyorBelt )
        {
            Instantiate(spot, transform.position, Quaternion.identity);
            transform.Translate(new Vector3(spaceBetweenSpots, 0, 0));
        }
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
