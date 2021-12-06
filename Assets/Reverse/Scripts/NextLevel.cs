using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static NextLevel instance; 

    public GameObject LoadUI;

    public Animator transition;

    public float transitionTime = 2f;



    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

       
    }
    void Start()
    {

        transition.SetTrigger("LoadNextLevel_End");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    LoadUI.SetActive(true);



        //}

        if (collision.CompareTag("Player"))
            LoadNextLevel();

    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {

    //        LoadNextLevel();
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        LoadUI.SetActive(false);
    //    }
    //}


    public void LoadNextLevel()
    {
        StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }


    public void LoadSpecificLevel(string levelname)
    {
        StartCoroutine(LoadSpecLevel(levelname));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("LoadNextLevel_Start");

        PlayerMovement.instance.GetComponent<SpriteRenderer>().enabled = false;
        //PlayerMovement.instance.GetComponent<GameObject>().GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadSpecLevel(string levelName)
    {
        transition.SetTrigger("LoadNextLevel_Start");
        PlayerMovement.instance.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene("Level"+levelName);
    }
    


}