using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    public bool oneTime;

    public bool InsideTrigger;
    public bool OutsideTrigger;

    public GameObject LoadUI;
    private bool isTouched;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isTouched)&&  Input.GetKeyDown(KeyCode.E))
        {

            if (InsideTrigger)
            {
                InsideGravityManager.instance.ChangeAllGravity();
            }

            else if (OutsideTrigger)
            {
                OutsideGravityManager.instance.ChangeAllGravity();
            }

            else
            {
                GravityManager.instance.ChangeAllGravity();
            }
            






            if (oneTime == true) {

                Invalid();
            }
            
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadUI.SetActive(true);
            isTouched = true;


        }

        if (collision.CompareTag("Frame"))
        {
            GravityManager.instance.ChangeAllGravity();

            if (oneTime == true)
            {

                Invalid();
            }

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

    void Invalid()
    {
        this.GetComponentInParent<SpriteRenderer>().color = Color.black;
        this.gameObject.GetComponent<GravityTrigger>().enabled = false;
        this.gameObject.GetComponentInChildren<Canvas>().enabled = false;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
