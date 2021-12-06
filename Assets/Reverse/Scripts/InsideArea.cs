using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideArea : MonoBehaviour
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




        //if ((other.CompareTag("Player") || other.CompareTag("Iron"))&& (GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
        if (other.CompareTag("Player") || other.CompareTag("Iron"))
        {
            /*最开始的写法
             if (GravityManager.instance.items.Contains(other.gameObject))
             {
                 GravityManager.instance.items.Remove(other.gameObject);
                 Debug.Log("Normal_Remove  " + other.name);
                 if ((GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
                 {
                     StartCoroutine(WaitChangeGravity(other));
                 }
             }
            
            
            
             if (!InsideGravityManager.instance.items.Contains(other.gameObject))
             {
                 InsideGravityManager.instance.items.Add(other.gameObject);
            
                 Debug.Log("Inside_Add  " + other.name);
             }
             */
            
            
            Debug.Log("ontriggerenter");
            if(!GravityCondition.instance.isEquiped)
               GravityCondition.instance.GravityChange_MidToIn(other.gameObject);





        }


    }



    private void OnTriggerExit2D(Collider2D other)
    {

        //if (((other.CompareTag("Player") || other.CompareTag("Iron")) )&& (GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
        if (other.CompareTag("Player") || other.CompareTag("Iron"))
        {
            /*
            if (!GravityManager.instance.items.Contains(other.gameObject))
            {
                GravityManager.instance.items.Add(other.gameObject);
                
                Debug.Log("Normal_Add  " + other.name);
                
                if ((GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
                {
                    StartCoroutine(WaitChangeGravity(other));
                }
            }
            

            


            if (InsideGravityManager.instance.items.Contains(other.gameObject))
            {
                InsideGravityManager.instance.items.Remove(other.gameObject);
                Debug.Log("Inside_Remove  " + other.name);
            }    
            */
            

            
            
            

            if(!GravityCondition.instance.isEquiped)
               GravityCondition.instance.GravityChange_InToMid(other.gameObject);
            
            



        }
    }

    // IEnumerator WaitChangeGravity(Collider2D co)
    // {
    //     yield return new WaitForSeconds(0.2f);
    //     co.gameObject.GetComponent<SwitchGravity>().ChangeGravity();
    // }
    
    
    
    
    
}
