using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy {                   //Jonathan Depina and Matthew Virga
        
    private Transform myTransform;
    public Transform target;
    private void Awake()
    {
        myTransform = transform;
    }
    private void Start()
    {
        count = GameObject.FindGameObjectWithTag("Count");
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }
    private void FixedUpdate()
    {
        Move();
       
    }





    public override void Move()
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), speed * Time.deltaTime);

        myTransform.position += myTransform.forward * speed * Time.deltaTime;
        
    }
    }


