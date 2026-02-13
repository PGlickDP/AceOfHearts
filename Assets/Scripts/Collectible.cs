using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool shield;
    public bool bodyguard;
    public bool healthUp;
    public GameObject player;
    public GameObject shieldObject;
    public ShieldPower ShieldPower;
    public BodyguardScript BodyguardScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log("aaaaa");
        Destroy(gameObject);
       
        
    }*/


    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("TOUCH");
            if (shield)
            {
                ShieldPower.shieldOn = true;
                Destroy(gameObject);
            }
            if (bodyguard)
            {
                BodyguardScript.bgON = true;
                Destroy(gameObject);
            }

        }
    }
}
