using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public AudioSource hurt;
    
    public List<Transform> weaponsInv = new List<Transform>();                   //Jonathan Depina and Matthew Virga
    private Weapons it = new Weapons();
    public Transform smg;
    public Transform shotgun;
    public Transform rifle;
    public int health;
    int count = 0;

    public GameObject equipped;
    Vector3 StartPos;
    int weaponPos;

    public static bool isdead;



    public float speed;


    void Start()
    {

        isdead = false;
        health = 100;



        smg.gameObject.SetActive(false);
        rifle.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);


        StartPos = gameObject.transform.position;



    }

    void Update()
    {

        foreach (Transform t in weaponsInv)
        {
            if (t.gameObject.activeInHierarchy)
                
                Equip(weaponPos);



        }
      

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponPos = 0;
            if (count >=1)
            {
                weaponsInv[0].gameObject.SetActive(true);
                if (count >= 2)
                    weaponsInv[1].gameObject.SetActive(false);
                if (count >= 3)
                    weaponsInv[2].gameObject.SetActive(false);


            }
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
         //   if (weaponsInv[1])
           //     weaponPos = 1;
            if (count >=2)
            {

                weaponsInv[0].gameObject.SetActive(false);

                weaponsInv[1].gameObject.SetActive(true);
                if (count >=3)
                weaponsInv[2].gameObject.SetActive(false);



            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           // if (weaponsInv[2])
            //    weaponPos = 2;
            if (count >=3)

            {

                weaponsInv[0].gameObject.SetActive(false);

                weaponsInv[1].gameObject.SetActive(false);

                weaponsInv[2].gameObject.SetActive(true);


            }
        }


    }
    void FixedUpdate()
    {


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 300.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10f;

        transform.Rotate(0, x, 0);
        transform.Translate(-z, 0, 0);

    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            hurt.Play();
            health -= 10;
            
            gameObject.GetComponent<Renderer>().material.color = Color.red;



        }


        if (health == 0)
        {

            isdead = true;
            
        }

        switch (col.tag)
        {

            case "Rifle":
                col.enabled = false;
                col.gameObject.SetActive(false);
                count++;
                weaponsInv.Add(rifle.transform);
                break;

            case "Smg":
                col.enabled = false;
                col.gameObject.SetActive(false);
                count++;
                weaponsInv.Add(smg.transform);
                break;

            case "Shotg":
                col.enabled = false;
                col.gameObject.SetActive(false);
                count++;
                weaponsInv.Add(shotgun.transform);
                break;

        }
        if (col.tag == "Boost")
        {
            health += 100;
            col.gameObject.SetActive(false);
            
        }


    }
  

    void Equip(int i)
    {

        weaponsInv[i].position = equipped.transform.position;
        weaponsInv[i].rotation = equipped.transform.rotation;


    }
    public void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
   
    
   
    
 



