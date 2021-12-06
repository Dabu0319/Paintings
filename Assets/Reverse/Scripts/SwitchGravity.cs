using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    public bool top;

    private Rigidbody2D rb;
    //private PlayerMovement playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerMovement = GetComponent<PlayerMovement>();
    }

    // 为什么这里fixedupdate就会有问题, 按键失灵
    void Update()
    {

        
    }

    void Rotation()
    {
        if (top)
        {
            //为什么这边赋值不需要class
            PlayerMovement.instance.gravityStates = GravityStates.Normal;
            transform.eulerAngles = Vector3.zero;
            top = !top;

        }
        else if (!top)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            PlayerMovement.instance.gravityStates = GravityStates.Reverse;

            top = !top;
        }
        
        
        

    }


    public void ChangeGravity()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    rb.gravityScale *= -1;

        //    if (this.name == "Player")
        //    {

        //        Rotation();

        //    }


        //}


        rb.gravityScale *= -1;

        if (this.name == "Player")
        {

            Rotation();
            PlayerMovement.instance.facingRight = !PlayerMovement.instance.facingRight;


        }

        if (this.name == "Armor")
        {
            Rotation();

        }
    }
}
