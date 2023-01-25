using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMannequin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mannequin"))
        {
            other.gameObject.GetComponent<TurnHead>().isObserved = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mannequin"))
        {
            other.gameObject.GetComponent<TurnHead>().isObserved = false;
        }
    }
}
