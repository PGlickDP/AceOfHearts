using System.Collections;
using UnityEngine;

public class BodyguardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool bgON;
    public int GuardNum;
    public GameObject[] bgs;
    //public float bgTime;
    public bool stopTime;
    void Start()
    {
        bgON = false;
        stopTime = false;
        for (int a = 0; a < bgs.Length; a++)
        {
            bgs[a].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bgON)
        {
            Debug.Log("a");
            int random = Random.Range(0, 3);
            bgs[random].SetActive(true);
            StartCoroutine(guardMe());

            bgON = false;
            
        }
        if (stopTime)
        {
            
            for (int a = 0; a < bgs.Length; a++)
            {
                bgs[a].SetActive(false);
            }
            stopTime = false;

        }
    }


    public IEnumerator guardMe()
    {

       
        yield return new WaitForSeconds(4);
        stopTime = true;
        

    }
}
