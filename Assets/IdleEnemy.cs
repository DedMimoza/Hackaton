using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class IdleEnemy : MonoBehaviour
{
    private Enemy _enemyScript;
    private Vector3 start_pos;
    private Quaternion rotation;
    private float timer;
    private NavMeshAgent _agent;

    private void Start()
    {
        
        start_pos = transform.position;
        rotation = transform.rotation;
        Debug.Log(start_pos);
        _enemyScript = transform.GetChild(0).GetComponent<Enemy>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_enemyScript.canSeePlayer)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > 10f)
            {
                _agent.destination = start_pos;
                
            }
        }

        if (transform.position == start_pos && transform.rotation != rotation)
        {
            transform.rotation=Quaternion.Lerp(transform.rotation, rotation, 0.05f);
        }
        
    }

 
}
