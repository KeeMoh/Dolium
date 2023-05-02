using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDialogForce : MonoBehaviour
{
    
    public bool haveToBeClose; //edit during animation
    public GameObject mannequinDialoguesUI;
    void Start()
    {
        haveToBeClose = false;
    }

    void Update()
    {
        if (haveToBeClose)
        {
            haveToBeClose = false;
            ForceClose();
        }
    }

    public void ForceClose()
    {
        if (mannequinDialoguesUI.activeSelf)
        {
            mannequinDialoguesUI.SetActive(false);
        }
    }
}
