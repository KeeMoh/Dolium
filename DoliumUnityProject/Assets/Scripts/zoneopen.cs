using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneopen : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GameObject.Find("porte").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dishes"))

        {
            anim.SetBool("open", true);
        }
    }

    private void OnTriggerExit()
    {
        anim.SetBool("open", false);
    }
}
