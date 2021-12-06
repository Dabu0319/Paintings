using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour
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


        if (other.CompareTag("Player")&& (GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
        {
            StartCoroutine(WaitChangeGravity(other));
        }


    }



    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (  (other.CompareTag("Player")|| other.CompareTag("Iron")  )&& (GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
        {
            StartCoroutine(WaitChangeGravity(other));
        }
    }

     IEnumerator WaitChangeGravity(Collider2D co)
    {
        yield return new WaitForSeconds(0.2f);
        co.gameObject.GetComponent<SwitchGravity>().ChangeGravity();
    }



}
