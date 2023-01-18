using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GetComponent<Interaction>().interactionState)
        {
            GameObject player = other.gameObject;
            player.GetComponent<ThirdPersonController>().GravityIsChanging = true;
            player.GetComponent<Animator>().SetTrigger("GravityChanged");
            GetComponent<Interaction>().interactionState = false;
        }
    }
}
