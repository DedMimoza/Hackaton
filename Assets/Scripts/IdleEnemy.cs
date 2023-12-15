using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class IdleEnemy : MonoBehaviour
{
    public Enemy _enemyScript;
    private Vector3 _start_pos = Vector3.zero;
    public Vector3 start_pos
    {
        get
        {
            return _start_pos;
        }
        set
    {
        if (_start_pos == Vector3.zero)
        {
            _start_pos = value;
        }
    } }
    private Quaternion rotation;
    private float timer;
    private NavMeshAgent _agent;

    private void Start()
    {
        
        rotation = transform.rotation;

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
            transform.rotation=Quaternion.Lerp(transform.rotation, rotation, 0.005f);
        }
        
    }

 
}
