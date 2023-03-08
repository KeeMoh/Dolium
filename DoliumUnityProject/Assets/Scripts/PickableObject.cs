using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Collider coll, trigger;
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
        Debug.Log(RightHandHandle.grabObj.name);
        RightHandHandle.grabObj.transform.parent = null;
        RightHandHandle.grabObj = null;
    }

    public void PickUp()
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
        trigger.enabled = false;
        coll.enabled = false;
        Debug.Log(player.name);
        player.GetComponent<InteractionController>().DeleteInteraction(gameObject);

    }

    public bool isPickable()
    {
        return (objectContainer.childCount == 0);
    }

}