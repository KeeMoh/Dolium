using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceController : MonoBehaviour
{
    public float element1Weight;
    public float element2Weight;

    public Transform element1;
    public Transform element2;

    public float speed = 0.1f;
    private float rotationSpeed;

    private bool isBalanced;

    void Update()
    {

        if (!isBalanced)
        {
            ChangeState();
        }
        else
        {
            Debug.Log("ChangeGravity");
        }

        
    }

    void ChangeState()
    {
        if (element1Weight < element2Weight)
        {
            rotationSpeed = speed* (element2Weight * 1/element1Weight);
            if (transform.rotation.eulerAngles.z > 344 || transform.rotation.eulerAngles.z < 15)
            {
                Balance(1);
            }
        }
        if (element2Weight < element1Weight)
        {
            rotationSpeed = speed * (element1Weight * 1/element2Weight);
            if (transform.rotation.eulerAngles.z > 345 || transform.rotation.eulerAngles.z < 16)
            {
                Balance(-1);
            }
        }
        if (element1Weight == element2Weight)
        {
            rotationSpeed = speed;
            if (transform.rotation.eulerAngles.z > -0.0001 && transform.rotation.eulerAngles.z < 0.0001)
            {
                isBalanced= true;
            }
            else if (transform.rotation.eulerAngles.z > 344 || transform.rotation.eulerAngles.z < 0.0001)
            {
                Balance(1);
            }
            else if (transform.rotation.eulerAngles.z < 16 && transform.rotation.eulerAngles.z > 0)
            {
                Balance(-1);
            }
        }
    }

    void Balance(int way)
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, way * rotationSpeed * Time.deltaTime);
        element1.rotation *= new Quaternion(0, 0, -way * rotationSpeed * Time.deltaTime/100, 1);
        element2.rotation *= new Quaternion(0, 0, -way * rotationSpeed * Time.deltaTime/100, 1);
    }
}
