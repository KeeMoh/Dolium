using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandHandle : MonoBehaviour
{
    private GameObject obj, objZone;
    private Rigidbody rb;
    private BoxCollider coll;
    public Transform player, Cam;

    public float dropForwardForce, dropUpwardForce;
    private bool islock;

    private StarterAssets.StarterAssetsInputs _input;

    private void Start()
    {
        _input = player.GetComponent<StarterAssets.StarterAssetsInputs>();
        _input.discard = false;
    }

    private void Update()
    {
        if (!islock)
        {
            if (_input.discard && isCarried())
            {
                islock = true;
                Drop();
            }
        }
    }
    private void Drop()
    {
        obj = transform.GetChild(0).gameObject;
        objZone = transform.GetChild(0).GetChild(0).gameObject;
        rb = obj.GetComponent<Rigidbody>();
        coll = obj.GetComponent<BoxCollider>();

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(Cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(Cam.up * dropUpwardForce, ForceMode.Impulse);

        rb.AddTorque(new Vector3(1, -0.3f, -0.3f) * 10);
        _input.discard = false;

        transform.GetChild(0).SetParent(null);
        objZone.SetActive(true);

        islock = false;
    }

    public bool isCarried()
    {
        return (transform.childCount > 0);
    }

}
