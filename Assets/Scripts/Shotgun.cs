using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;                      //Jonathan Depina and Matthew Virga

namespace Assets
{
    class Shotgun : Weapons
    {
        
        public GameObject shotspawn;
        public GameObject shotspawn2;
        public override void Start()
        {
           timer = 50;

        }

       
        public override void Shoot()
        {
            
                Rigidbody instProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instProjectile.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
                Rigidbody iProjectile = Instantiate(projectile, shotspawn.transform.position, transform.rotation) as Rigidbody;
                iProjectile.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
                Rigidbody insProjectile = Instantiate(projectile, shotspawn2.transform.position, transform.rotation) as Rigidbody;
                insProjectile.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
            
        }
    }
}
