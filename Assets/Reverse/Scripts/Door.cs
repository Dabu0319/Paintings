using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destination;
    
    public GameObject LoadUI;
    private bool isTouched;
    
    public bool inToMidDoor;
    public bool midToInDoor;
    public bool midToOutDoor;
    public bool outToMidDoor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isTouched) && Input.GetKeyDown(KeyCode.E))
        {

            GameObject player = PlayerMovement.instance.gameObject;
            PlayerMovement.instance.gameObject.transform.position = destination.transform.position;


            if (inToMidDoor)
            {
                // if ((GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
                // {
                //     PlayerMovement.instance.gameObject.GetComponent<SwitchGravity>().ChangeGravity();
                // }
                GravityCondition.instance.GravityChange_InToMid(player);
            }

            if (midToInDoor)
            {
                // if ((OutsideGravityManager.instance.isNormal != GravityManager.instance.isNormal))
                // {
                //     PlayerMovement.instance.gameObject.GetComponent<SwitchGravity>().ChangeGravity();
                // }
                GravityCondition.instance.GravityChange_MidToIn(player);
            }

            if (midToOutDoor)
            {
                GravityCondition.instance.GravityChange_MidToOut(player);
            }

            if (outToMidDoor)
            {
                GravityCondition.instance.GravityChange_OutToMid(player);
            }
            
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            LoadUI.SetActive(true);
            isTouched = true;


        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            
            LoadUI.SetActive(false);
            isTouched = false;
        }
    }
}
