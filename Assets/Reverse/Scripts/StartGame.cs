using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string level;
    public GameObject LoadUI;
    private bool isTouched;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isTouched) && Input.GetKeyDown(KeyCode.Return))
        {

            NextLevel.instance.LoadSpecificLevel(level);
            
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadUI.SetActive(true);
            isTouched = true;


        }




    }
}
