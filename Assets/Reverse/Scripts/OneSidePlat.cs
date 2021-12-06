using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSidePlat : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    public float waitTimeValue=0.2f;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonUp("Down"))
        {
            waitTime = waitTimeValue;
        }




        if (PlayerMovement.instance.gravityStates == GravityStates.Normal)
        {
            if (Input.GetButton("Down"))
            {
                if (waitTime <= 0)
                {
                    effector.rotationalOffset = 180f;
                    waitTime = waitTimeValue;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            if (Input.GetButton("Jump"))
            {
                effector.rotationalOffset = 0;
            }
        }
        else if (PlayerMovement.instance.gravityStates == GravityStates.Reverse)
        {
            if (Input.GetButton("Down"))
            {
                if (waitTime <= 0)
                {
                    effector.rotationalOffset = 0f;
                    waitTime = waitTimeValue;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            if (Input.GetButton("Jump"))
            {
                effector.rotationalOffset = 180f;
            }
        }


    }
}
