using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer sp;
    public int ShieldHealth;
    public bool shieldOn;
    void Start()
    {
        sp.enabled = false;
        ShieldHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldOn)
        {
            sp.enabled = true;
            if (ShieldHealth == 0)
            {
                sp.enabled = false;
                shieldOn = false;
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (shieldOn)
        {
            if (other.gameObject.layer.Equals("Projectile"))
            {
                ShieldHealth--;
            }

        }
        
    }


}
