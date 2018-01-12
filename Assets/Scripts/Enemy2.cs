using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;                       //Jonathan Depina and Matthew Virga

public class Enemy2 : Enemy {

     
    

     NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        count = GameObject.FindGameObjectWithTag("Count");
        
    }
	
	
	public override void Move () {
        GameObject destination = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(destination.transform.position);
        
	}
}
