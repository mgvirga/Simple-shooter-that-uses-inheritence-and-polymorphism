using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class weaponsspawner : MonoBehaviour {
    
    public List<Transform> weapons;
    public List<Transform> wspawns;
    // Use this for initialization
    void Start () {
        Spawn();
	}
	
	
	
    void Spawn()
    {
        
        
        for (int i = 0; i < 3; i++)
        {
            if (weapons[i].gameObject.tag == "Rifle"){
            int r = Random.Range(0, 4);
            weapons[i].gameObject.SetActive(true);
            Instantiate(weapons[i], wspawns[r].position, wspawns[i].rotation);
        }
            if (weapons[i].gameObject.tag == "Smg")
            {
                int r = Random.Range(5, 6);
                weapons[i].gameObject.SetActive(true);
                Instantiate(weapons[i], wspawns[r].position, wspawns[i].rotation);
            }
            if (weapons[i].gameObject.tag == "Shotg")
            {
                int r = Random.Range(7, 10);
                weapons[i].gameObject.SetActive(true);
                Instantiate(weapons[i], wspawns[r].position, wspawns[i].rotation);
            }
        }
      
    }
}
