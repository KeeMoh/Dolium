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
            //player.transform.localPosition = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
            //GetComponent<Interaction>().interactionState = false;
            Debug.Log("test");
        }
    }
}
