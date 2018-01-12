using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public GameObject count;
    public GameObject player;
    public GameObject enemy;                //Jonathan Depina and Matthew Virga
    public Vector3 toTarget;
    public float speed = 1.5f;
    public float angle;
    public Vector3 direction;
    public static int counter;

    
    void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
        count = GameObject.FindGameObjectWithTag("Count");
        
    }

    public void Update()
    {
        Move();
       
    }



    public virtual void Move()
    {
        direction = player.transform.position - transform.position;
        transform.position += direction * 1f * Time.deltaTime;
        direction.Normalize();
        angle = Mathf.Atan2(direction.z, direction.x);
        transform.eulerAngles = new Vector3(0f, angle, 0f);
    }
    public void OnTriggerEnter(Collider bullet)
    {
        if(bullet.tag == "Bullet")
        {
            
            Destroy(gameObject);
            setCount();


        }
    }
    public void setCount()
    {
        
        counter+=1;
        count.GetComponent<Text>().text = "Points: " + counter.ToString();
        
        PlayerPrefs.SetInt("YourScore", counter);
        
    }
   
   
}
