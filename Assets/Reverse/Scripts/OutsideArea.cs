using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {


        //if ((other.CompareTag("Player") || other.CompareTag("Iron")) && (GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
        //{
        //    StartCoroutine(WaitChangeGravity(other));


        //}
        
        
        if (other.CompareTag("Player") || other.CompareTag("Iron"))
        {
            
            // GravityManager.instance.items.Remove(other.gameObject);
            // OutsideGravityManager.instance.items.Add(other.gameObject);
            //
            // if ((GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
            // {
            //     StartCoroutine(WaitChangeGravity(other));
            // }

               GravityCondition.instance.GravityChange_MidToOut(other.gameObject);

        }
        

    }



    private void OnTriggerExit2D(Collider2D other)
    {

        //if ((other.CompareTag("Player") || other.CompareTag("Iron")) && (GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
        //{
        //    StartCoroutine(WaitChangeGravity(other));

        GravityManager.instance.items.Add(other.gameObject);
        OutsideGravityManager.instance.items.Remove(other.gameObject);
        //}

        if ((other.CompareTag("Player") || other.CompareTag("Iron")))
        {
            //
            // GravityManager.instance.items.Add(other.gameObject);
            // OutsideGravityManager.instance.items.Remove(other.gameObject);
            //
            // if ((GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
            // {
            //     StartCoroutine(WaitChangeGravity(other));
            // }


              GravityCondition.instance.GravityChange_OutToMid(other.gameObject);
        }
    }

    // IEnumerator WaitChangeGravity(Collider2D co)
    // {
    //     yield return new WaitForSeconds(0.2f);
    //     co.gameObject.GetComponent<SwitchGravity>().ChangeGravity();
    // }
}
