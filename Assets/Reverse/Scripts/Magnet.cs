using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Iron"))
        {

            Debug.Log("11");
            StartCoroutine(MoveTo(collision.transform.parent.transform, this.transform.position, 500));

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


    }



    private IEnumerator MoveTo(Transform tr, Vector3 pos, float time)
    {
        float t = 0;
        while (true)
        {
            t += Time.deltaTime;
            float a = t / time;
            tr.position = Vector3.Lerp(tr.position, pos, a);
            if (a >= 1.0f)
                break;
            yield return null;
        }

    }

}
