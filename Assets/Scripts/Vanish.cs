using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour {
    public GameObject Bullet;
    int timer;                                  // Jonathan Depina and Matthew Virga

    void Start()
    {
         timer = 50;
    }
	void Update ()
    {

        timer--;
        if (timer <= 0)
            Destroy(Bullet);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.Bullet);
        }
    }
}
