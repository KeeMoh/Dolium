using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandHandle : MonoBehaviour
{
    private GameObject obj;
    private Rigidbody rb;
    private Collider coll, trigger;
    public Transform player, Cam;
    static public GameObject grabObj;

    public float dropForwardForce, dropUpwardForce;
    private bool islock;

    private StarterAssets.StarterAssetsInputs _input;

    private void Start()
    {
        _input = player.GetComponent<StarterAssets.StarterAssetsInputs>();
        _input.discard = false;
        grabObj = null;
    }

    private void Update()
    {
        if (!islock)
        {
            if (_input.discard && RightHandHandle.grabObj != null)
            {
                islock = true;
                Drop();
            }
        }
    }
    private void Drop()
    {
        obj = transform.GetChild(0).gameObject;
        rb = obj.GetComponent<Rigidbody>();

        coll = obj.GetComponent<PickableObject>().coll;
        trigger = obj.GetComponent<PickableObject>().trigger;

        rb.isKinematic = false;
        coll.enabled = true;
        trigger.enabled = true;
        coll.isTrigger = false;

        //rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(Cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(Cam.up * dropUpwardForce, ForceMode.Impulse);

        rb.AddTorque(new Vector3(1, -0.3f, -0.3f) * 10);
        _input.discard = false;

        transform.GetChild(0).SetParent(null);
        RightHandHandle.grabObj = null;
        islock = false;
    }

}
