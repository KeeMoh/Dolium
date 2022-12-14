using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlateZone : MonoBehaviour
{
    public Transform plate1Container;
    public Transform plate2Container;
    private Rigidbody rb;
    private BoxCollider coll;
    public RightHandHandle rightHand;
    private bool islock;

    private void OnTriggerStay(Collider other)
    {
        if (!islock)
        {
            if (other.gameObject.CompareTag("Dishes"))
            {
                islock = true;
                placeObject(other);
            }
        }
    }

    private void placeObject(Collider obj)
    {
        rb = obj.GetComponent<Rigidbody>();
        coll = obj.GetComponent<BoxCollider>();

        if (obj.gameObject.name == "Plate1")
        {
            obj.transform.SetParent(plate1Container);
        }
        else if (obj.gameObject.name == "Plate2")
        {
            obj.transform.SetParent(plate2Container);
        }
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        obj.transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = false;
        islock = false;
    }
}
