using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public GameObject LoadUI;
    private bool isTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isTouched) && Input.GetKeyDown(KeyCode.E))
        {
            ChangeDirection();
            EquipArmor();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouched = true;
            LoadUI.SetActive(true);

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadUI.SetActive(false);
            isTouched = false;
        }
    }


    void EquipArmor()
    {

        if (GravityCondition.instance.gameObject)
        {
            GravityCondition.instance.isEquiped = true;
        }
        
        
        //说实话越调整越乱..到后面都不知道是哪个发挥的实际效果
        this.transform.parent = PlayerMovement.instance.GetComponentInParent<Transform>();
        this.transform.position = PlayerMovement.instance.GetComponentInParent<Transform>().position;

        LoadUI.SetActive(false);

        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponentInChildren<BoxCollider2D>().enabled =false;

        this.GetComponent<SwitchGravity>().enabled = false;

        this.GetComponent<Rigidbody2D>().isKinematic = true;


        //加了GravityManager之后失效
        //PlayerMovement.instance.GetComponentInParent<SwitchGravity>().enabled = false;

        //Range移除
        //虽然不影响但是会有报错, out of bound
        //GravityManager.instance.items.RemoveRange(0,2);

        // GravityManager.instance.items.Remove(this.gameObject);
        // GravityManager.instance.items.Remove(this.transform.parent.gameObject);
        //
        // InsideGravityManager.instance.items.Remove(this.gameObject);
        // InsideGravityManager.instance.items.Remove(this.transform.parent.gameObject);
        // OutsideGravityManager.instance.items.Remove(this.gameObject);
        // OutsideGravityManager.instance.items.Remove(this.transform.parent.gameObject);


        

        

        //PlayerMovement.instance.jumpForce = 0f;
    }


    void ChangeDirection()
    {
        //两种情况, 后面加了个还没有装备的判定



        if(!PlayerMovement.instance.facingRight && !this.GetComponent<SwitchGravity>().top && (this.transform.parent != PlayerMovement.instance.GetComponentInParent<Transform>()))
        {

            PlayerMovement.instance.Flip(this.gameObject );

            Debug.Log("Flip1");
        }

        if (PlayerMovement.instance.facingRight && this.GetComponent<SwitchGravity>().top && (transform.parent != PlayerMovement.instance.GetComponentInParent<Transform>()))
        {

            PlayerMovement.instance.Flip(this.gameObject);
            Debug.Log("Flip2");
        }
    }
}
