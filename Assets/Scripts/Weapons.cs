using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public GameObject smg;
    public GameObject shotgun;                      // Jonathan Depina and Matthew Virga
    public GameObject rifle;
    public GameObject BulletSpawn;
    public Rigidbody projectile;
    public float speed = 50;
    public int timer = 1;
    public int currenttimer = 0;
     List<Transform> list;

   public  virtual void Start()
    {
        list = GetComponent<PlayerMove>().weaponsInv;

        timer = 50;
    }


    public virtual void Update()
    {
        
        
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (currenttimer <= 0)
                {
                    Shoot();
                    currenttimer = timer;
                }
            }
            currenttimer--;
        
    }
  
    public virtual void Shoot()
    {
        
            Rigidbody instProjectile = Instantiate(projectile, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as Rigidbody;
            instProjectile.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
        
    }
    
}
