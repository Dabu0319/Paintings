using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于判断进入离开不同区域的manager的list改变
public class GravityCondition : MonoBehaviour
{
    public static GravityCondition instance;
    // Start is called before the first frame update
    
    public bool isEquiped;
    
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GravityChange_MidToIn(GameObject changeObj)
    {
        if (!GravityCondition.instance.isEquiped)
        {
            //判断下是否包含该物体
            if(GravityManager.instance.items.Contains(changeObj))
            {
                //移除
                GravityManager.instance.items.Remove(changeObj);
                Debug.Log("Mid_Remove  " + changeObj.name);
            
                //如果两者所处Area的重力系数不相同,则选择去改变一次
                //放在里面的原因是因为像Armor如果有两个collider会判断两次
                if ((GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
                {
                    changeObj.GetComponent<SwitchGravity>().ChangeGravity();
                }
            
            }

            if (!InsideGravityManager.instance.items.Contains(changeObj))
            {
                //增加
                InsideGravityManager.instance.items.Add(changeObj);

                Debug.Log("In_Add  " + changeObj.name);
            

            
            }
        }

        
        
        
    }
    public void GravityChange_InToMid(GameObject changeObj)
    {
        if (!GravityCondition.instance.isEquiped)
        {
            if(InsideGravityManager.instance.items.Contains(changeObj))
            {
                //移除
                InsideGravityManager.instance.items.Remove(changeObj);
                Debug.Log("In_Remove  " + changeObj.name);
            
                if ((GravityManager.instance.isNormal != InsideGravityManager.instance.isNormal))
                {
                    changeObj.GetComponent<SwitchGravity>().ChangeGravity();
                }
            
            }

            if (!GravityManager.instance.items.Contains(changeObj))
            {
                //增加
                GravityManager.instance.items.Add(changeObj);

                Debug.Log("Mid_Add  " + changeObj.name);
            


            
            }
        }
        

        
        
    }
    public void GravityChange_MidToOut(GameObject changeObj)
    {

        if (!GravityCondition.instance.isEquiped)
        {
            if(GravityManager.instance.items.Contains(changeObj))
            {
                //移除
                GravityManager.instance.items.Remove(changeObj);
                Debug.Log("Mid_Remove  " + changeObj.name);
            
            
                if ((GravityManager.instance.isNormal != OutsideGravityManager.instance.isNormal))
                {
                    changeObj.GetComponent<SwitchGravity>().ChangeGravity();
                }
            
            }

            if (!OutsideGravityManager.instance.items.Contains(changeObj))
            {
                //增加
                OutsideGravityManager.instance.items.Add(changeObj);

                Debug.Log("Out_Add  " + changeObj.name);
            

            
            }
        }

        
        
        
    }
    public void GravityChange_OutToMid(GameObject changeObj)
    {
        if (!GravityCondition.instance.isEquiped)
        {
            if(OutsideGravityManager.instance.items.Contains(changeObj))
            {
                //移除
                OutsideGravityManager.instance.items.Remove(changeObj);
                Debug.Log("Out_Remove  " + changeObj.name);
            
                if ((GravityManager.instance.isNormal != OutsideGravityManager.instance.isNormal))
                {
                    changeObj.GetComponent<SwitchGravity>().ChangeGravity();
                }
            }

            if (!GravityManager.instance.items.Contains(changeObj))
            {
                //增加
                GravityManager.instance.items.Add(changeObj);

                Debug.Log("Mid_Add  " + changeObj.name);
            


            
            }
        }

        
        
        
    }
    
}
