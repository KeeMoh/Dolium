using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    [SerializeField] private Transform neck;
    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform baseDirection;
    public bool isObserved = false;
    // Start is called before the first frame update
    float Speed = 1.0f;


    // Update is called once per frame
    void Update()
    {
        


        if (!isObserved)
        {
            Vector3 directionTurn = (playerHead.position - neck.position).normalized;
            float singleStep = Speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(neck.forward, directionTurn, singleStep, 0.0f);

            Debug.DrawRay(neck.position, newDirection, Color.red);
            neck.rotation = Quaternion.LookRotation(newDirection);

        }
        else
        {
            Vector3 directionTurn = (baseDirection.position - neck.position).normalized;

            float singleStep = 10.0f * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(neck.forward, directionTurn, singleStep, 0.0f);
            Debug.DrawRay(neck.position, newDirection, Color.blue);

            neck.rotation = Quaternion.LookRotation(newDirection);
        }


    }


}
