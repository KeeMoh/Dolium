using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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

    public GameObject player;

    void Update()
    {

        if (!isBalanced)
        {
            ChangeState();
        }
        else if (player.GetComponent<ThirdPersonController>().GravityIsChanging)
        {
        }


        PlaceObject();
        
    }

    void ChangeState()
    {
        if (element2Weight < element1Weight)
        {
            rotationSpeed = speed* (element1Weight * 1/element2Weight);
            if (transform.rotation.eulerAngles.z < 16 || transform.rotation.eulerAngles.z > 335)
            {
                Balance(1);

            }

        }
        if (element1Weight < element2Weight)
        {
            rotationSpeed = speed * (element2Weight * 1/element1Weight);
            if (transform.rotation.eulerAngles.z > 344 || transform.rotation.eulerAngles.z < 20)
            {
                Balance(-1);
            }
        }
        if (element1Weight == element2Weight)
        {
            rotationSpeed = speed;
            if (transform.rotation.eulerAngles.z > -1 && transform.rotation.eulerAngles.z < 1)
            {
                isBalanced= true;
                player.GetComponent<ThirdPersonController>().GravityIsChanging = true;
                //player.GetComponent<Animator>().SetTrigger("GravityChanged");
            }
            else if (transform.rotation.eulerAngles.z > 335 || transform.rotation.eulerAngles.z < 0.001)
            {
                Balance(1);
            }
            else if (transform.rotation.eulerAngles.z < 20 && transform.rotation.eulerAngles.z > 0)
            {
                Balance(-1);
            }
        }
    }

    void Balance(int way)
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, way * rotationSpeed * Time.deltaTime);
        element1.rotation *= new Quaternion(0, 0, 0.88f * -way * rotationSpeed * Time.deltaTime/100, 1);
        element2.rotation *= new Quaternion(0, 0, 0.88f * -way * rotationSpeed * Time.deltaTime/100, 1);
        Debug.Log("Change State " + transform.rotation.eulerAngles.z);
    }

    //Update

    void PlaceObject()
    {
        if (element1.GetComponent<Interaction>().interactionState)
        {
            Debug.Log("Interaction element 1");
            if (RightHandHandle.grabObj == null || RightHandHandle.grabObj.GetComponent<BalancePickableObjects>() == null)
            {
                element1.GetComponent<Interaction>().interactionState = false;
                return;
            }
            GameObject grabObj = RightHandHandle.grabObj;
            if (element1.GetComponent<BalancePlacement>().pickableObject != null)
            {
                BalancePickableObjects placedObj = element1.GetComponent<BalancePlacement>().pickableObject;
                element1.GetComponent<BalancePlacement>().pickableObject = grabObj.GetComponent<BalancePickableObjects>();
                element1Weight = grabObj.GetComponent<BalancePickableObjects>().weight;
                grabObj.transform.SetParent(element1, false);
                grabObj.transform.position = element1.GetChild(0).position;
                grabObj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                placedObj.PickUp();

                
            }
            else
            {
                element1.GetComponent<BalancePlacement>().pickableObject = grabObj.GetComponent<BalancePickableObjects>();
                element1Weight = RightHandHandle.grabObj.GetComponent<BalancePickableObjects>().weight;
                RightHandHandle.grabObj.transform.SetParent(element1, false);
                RightHandHandle.grabObj.transform.position = element1.GetChild(0).position;
                RightHandHandle.grabObj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                RightHandHandle.grabObj = null;
            }

            
            
            element1.GetComponent<Interaction>().interactionState = false;
            
        }
        else if (element2.GetComponent<Interaction>().interactionState)
        {
            if (RightHandHandle.grabObj != null)
            {
                element2.GetComponent<BalancePlacement>().pickableObject = RightHandHandle.grabObj.GetComponent<BalancePickableObjects>();
                element2Weight = RightHandHandle.grabObj.GetComponent<BalancePickableObjects>().weight;

                RightHandHandle.grabObj.transform.SetParent(element2, false);
                RightHandHandle.grabObj.transform.position = element2.GetChild(0).position;
                RightHandHandle.grabObj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                RightHandHandle.grabObj = null;
            }
            element2.GetComponent<Interaction>().interactionState = false;
        }

    }
}
