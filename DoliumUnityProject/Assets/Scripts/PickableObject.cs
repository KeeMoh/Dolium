using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public BoxCollider coll;
    public Transform player, objectContainer, Cam;
    private Interaction _interaction;

    private bool islock = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _interaction = GetComponent<Interaction>();
        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (!islock)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                if (_interaction.interactionState)
                {

                    if (RightHandHandle.grabObj != null)
                    {
                        if (gameObject != RightHandHandle.grabObj)
                        {
                            islock = true;
                            DropGround();
                            PickUp();
                        }
                    } else
                    {
                        islock = true;
                        PickUp();
                    }
                    
                }

            }
        }
    }

    private void DropGround()
    {
        RightHandHandle.grabObj.GetComponent<Rigidbody>().isKinematic = false;
        RightHandHandle.grabObj.GetComponents<BoxCollider>()[0].isTrigger = false;
        objectContainer.GetChild(0).SetParent(null);
        RightHandHandle.grabObj = null;
    }

    private void PickUp()
    {
        transform.SetParent(objectContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        coll.isTrigger = true;
        _interaction.interactionState = false;
        RightHandHandle.grabObj = transform.gameObject;
        islock = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.name);
        player.GetComponent<InteractionController>().DeleteInteraction(gameObject);

    }

}