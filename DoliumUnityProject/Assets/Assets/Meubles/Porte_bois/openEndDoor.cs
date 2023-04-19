using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openEndDoor : MonoBehaviour
{
    public Animator openEndDoorAnimator;
    private void OnTriggerEnter(Collider other)
    {
        openEndDoorAnimator.SetBool("end", true);
    }
}
