using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public GameObject projectile;
    public float fireRate;
    public float nextFire;
    public GameObject shootPoint;
    public string type;
    public bool loopA;
    public bool loopB;
    public float shootUpTimer;
    Quaternion Up = Quaternion.LookRotation(Vector2.up);
    Quaternion Down = Quaternion.LookRotation(Vector2.down);
    Quaternion Left = Quaternion.LookRotation(Vector2.left);
    Quaternion Right = Quaternion.LookRotation(Vector2.right);
    //public float bulletSpeed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loopA = false;
        loopB = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (Vector2.Distance(player.transform.position, transform.position));
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);

        if (gameObject.CompareTag("Fan"))
        {
            nextFire += Time.deltaTime;
            if (nextFire > fireRate)
            {
                nextFire = 0;
                Shoot();
                loopA = true;
            }
        }

       if(gameObject.CompareTag("Fan Four"))
        {
            nextFire += Time.deltaTime;
            if (nextFire > fireRate)
            {
                nextFire = 0;
                ShootFour();
            }
        }

        if (loopA)
        {
            StartCoroutine(waitToIncrease());
            loopA = false;
        }

        if (loopB) 
        { 
           if(fireRate > 1)
            {
                fireRate--;
            }
            if (fireRate == 1)
            {
                fireRate = 1;
            }
            loopB = false;
            
        }


    }



    public void Shoot()
    {
        GameObject shot = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
        
    }


    public IEnumerator waitToIncrease()
    {
       
        yield return new WaitForSeconds(30);
      
        loopB = true;
    }

    public void ShootFour()
    {
        
        /*GameObject sOne = Instantiate(projectile, shootPoint.transform.position, Up);
        GameObject sTwo = Instantiate(projectile, shootPoint.transform.position, Right);
        GameObject sThree = Instantiate(projectile, shootPoint.transform.position, Down);
        GameObject sFour = Instantiate(projectile, shootPoint.transform.position, Left);*/
    }


}