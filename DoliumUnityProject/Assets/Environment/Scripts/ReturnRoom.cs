using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnRoom : MonoBehaviour
{
    public GameObject room;
    private void Update()
    {
        if (GetComponent<Interaction>().interactionState && room.transform.rotation.x < 0.99999)
        {
            room.transform.rotation *= Quaternion.Euler(100f*Time.deltaTime, 0, 0);
            Debug.Log(room.transform.rotation.x);
        }
    }
}
