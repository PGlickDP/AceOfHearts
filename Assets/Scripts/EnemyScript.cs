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
    //public float bulletSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

    }


    public void Shoot()
    {
        Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
    }

    public void ShootFour()
    {

    }


}