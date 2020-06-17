using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragByTouch : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if( Input.touchCount > 0 )
        {
            Touch t = Input.GetTouch(0);
            Vector3 tPos = Camera.main.ScreenToWorldPoint(t.position);
            tPos.z = 0;
            transform.position = tPos;
        }
    }
}
