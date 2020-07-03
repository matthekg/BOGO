using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Minimize : MonoBehaviour
{
    public GameObject objectToMinimize;
    public GameObject otherMinimizer;
    public bool IAmOpen = false;

    public void ToggleOpen()
    {
        if (IAmOpen)
            Close();
        else
            Open();
    }

    private void Open()
    {
        objectToMinimize.SetActive(true);
        otherMinimizer.SetActive(false);
        otherMinimizer.GetComponent<Minimize>().IAmOpen = false;
        IAmOpen = true;
    }

    private void Close()
    {
        objectToMinimize.SetActive(false);
        IAmOpen = false;
    }
}
