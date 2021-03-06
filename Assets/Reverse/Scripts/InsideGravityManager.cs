using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InsideGravityStates
{
    Null,
    Normal,
    Reverse

}

public class InsideGravityManager : MonoBehaviour
{
    public bool isNormal=true;

    public bool isEquiped;
    
    public static InsideGravityManager instance;

    public List<GameObject> items = new List<GameObject>();


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

    public void ChangeAllGravity()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.GetComponent<SwitchGravity>().ChangeGravity();
        }

        isNormal = !isNormal;
    }
}
