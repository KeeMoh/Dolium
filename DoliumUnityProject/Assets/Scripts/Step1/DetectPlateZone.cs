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
    public GameObject player;
    private bool islock;
    static public bool plate1Validate;
    static public bool plate2Validate;

    private void Start()
    {
        RenderSettings.fogEndDistance = 5;
        plate1Validate = false;
        plate2Validate = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!islock)
        {
            if (other.gameObject.CompareTag("Dishes") && RightHandHandle.grabObj == null)
            {
                islock = true;
                placeObject(other);
            }
        }
    }

    private void Update()
    {
        if (((plate1Validate && !plate2Validate) || (!plate1Validate && plate2Validate)) && RenderSettings.fogEndDistance < 6)
        {
            RenderSettings.fogEndDistance += Time.deltaTime * 10;
}
        else if (plate1Validate && plate2Validate && RenderSettings.fogEndDistance < 20)
        {
            RenderSettings.fogEndDistance += Time.deltaTime * 10;
        }
    }

        

    private void placeObject(Collider obj)
    {
        rb = obj.GetComponent<Rigidbody>();
        coll = obj.GetComponent<BoxCollider>();

        if (obj.gameObject.name == "Plate1" && !plate1Validate)
        {
            obj.GetComponents<BoxCollider>()[1].enabled = false;
            obj.GetComponent<Interaction>().enabled = false;
            obj.GetComponent<Outline>().enabled = false;
            obj.GetComponent<PickableObject>().enabled = false;
            if (player.GetComponent<InteractionController>().gameObjectsInteractions != null)
            {
                player.GetComponent<InteractionController>().DeleteInteraction(obj.gameObject);
            }
            obj.transform.SetParent(plate1Container);
            plate1Validate = true;
        }
        else if (obj.gameObject.name == "Plate2" && !plate2Validate)
        {
            obj.GetComponents<BoxCollider>()[1].enabled = false;
            obj.GetComponent<Interaction>().enabled = false;
            obj.GetComponent<Outline>().enabled = false;
            obj.GetComponent<PickableObject>().enabled = false;
            if (player.GetComponent<InteractionController>().gameObjectsInteractions != null)
            {
                player.GetComponent<InteractionController>().DeleteInteraction(obj.gameObject);
            }
            obj.transform.SetParent(plate2Container);
            plate2Validate = true;
        }

        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        obj.transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = false;
        islock = false;
    }
}
