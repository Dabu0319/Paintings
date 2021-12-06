using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityStates
{
    Null,
    Normal,
    Reverse

}





public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;

    public GravityStates gravityStates = GravityStates.Normal;

    [Header("Horizontal")]
    public float speed= 5.0f;
    public bool facingRight = true;

    [Header("Vertical")]
    public float jumpForce;
    public int extraJumpsValue;
    private int extraJumps;
    //穿过时加的很小的力



    [Header("Ground")]
    public bool isGrounded;
    public float checkRadius;
    public Transform groundCheck_Normal;
    public LayerMask ground;



    private float horizontal;

    private Rigidbody2D rb;

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //如果有多个children怎么办？
        //另外如果自己有的话率先读取自身
        //groundCheck = GetComponentInChildren<Transform>();

        //?
        //groundCheck = transform.Find("Ground Check");


        ground = 1 << LayerMask.NameToLayer("Ground"); 
    }


    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump")&& extraJumps > 0)
        {
            if (gravityStates == GravityStates.Normal)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            else if (gravityStates == GravityStates.Reverse)
            {
                rb.velocity = Vector2.down * jumpForce;
            }
            
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            if (gravityStates == GravityStates.Normal)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            else if (gravityStates == GravityStates.Reverse)
            {
                rb.velocity = Vector2.down * jumpForce;
            }
            extraJumps--;
        }
        {

        }



    }





    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //isGrounded
        isGrounded = Physics2D.OverlapCircle(groundCheck_Normal.position, checkRadius, ground);


        //Flip
        if(facingRight ==false && horizontal > 0)
        {
            Flip(this.gameObject);
        }
        else if (facingRight == true && horizontal < 0)
        {
            Flip(this.gameObject);
        }

    }





    public void Flip(GameObject flipObj)
    {
        if (flipObj==PlayerMovement.instance.gameObject)
        {
            facingRight = !facingRight;
        }
        
        Vector3 scaler = flipObj.transform.localScale;
        scaler.x *= -1;
        flipObj.transform.localScale = scaler;



    }




}
