using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{


    public GameObject eBulletSpawn;
    public Rigidbody eBullet;
    public float speed = 50f;
    public int eTimer = 1;
    public int eCurrenttimer = 0;
    // Use this for initialization
    void Start()
    {
        eTimer = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (eCurrenttimer <= 0)
        {
           EShoot();
            eCurrenttimer = eTimer;
        }

        eCurrenttimer--;
    }
    public void EShoot()
    {
        Rigidbody instProjectile = Instantiate(eBullet, eBulletSpawn.transform.position, eBulletSpawn.transform.rotation) as Rigidbody;
        instProjectile.velocity = eBulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
    }
}
