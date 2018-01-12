using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets                        // Jonathan Depina and Matthew Virga
{
    class Rifle : Weapons
    {
        public GameObject riflespawn2;
        public override void Start()
        {
            timer = 20;

        }
        public override void Shoot()
        {

            Rigidbody instProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instProjectile.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
            Rigidbody iProjectile = Instantiate(projectile, riflespawn2.transform.position, transform.rotation) as Rigidbody;
            iProjectile.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
            

        }

    }
}