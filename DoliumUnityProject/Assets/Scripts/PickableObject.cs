using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{

    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, objectContainer, Cam;

    private bool islock = false;

    private StarterAssets.StarterAssetsInputs _input;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _input = other.GetComponent<StarterAssets.StarterAssetsInputs>();
            _input.grab = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (!islock)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                if (_input.grab && isPickable())
                {
                    islock = true;
                    PickUp();
                }

            }
        }
    }

    private void PickUp()
    {
        transform.parent.SetParent(objectContainer);
        transform.parent.localPosition = Vector3.zero;
        transform.parent.localRotation = Quaternion.Euler(Vector3.zero);
        transform.parent.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;
        transform.gameObject.SetActive(false);
        _input.grab = false;
        islock = false;
    }

    public bool isPickable()
    {
        return (objectContainer.childCount == 0);
    }

}