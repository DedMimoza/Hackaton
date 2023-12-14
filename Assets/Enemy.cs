using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TreeEditor;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    public bool canSeePlayer;
    
    public GameObject playerRef;
    
    
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [SerializeField, Range(0,5f)] public float radius;
    [SerializeField,Range(0, 360f)] public float angle;

    void Start()
    {
        _navMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            check();
        }
    }

    private void check()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    _navMeshAgent.speed = 3f;
                    canSeePlayer = true;
                    _navMeshAgent.destination = target.position;
                    transform.LookAt(target);
                    angle = 360f;
                }

                else
                {
                    canSeePlayer = false;
                    angle = 60f;
                }
            }
            else
            {
                canSeePlayer = false;
                angle = 60f;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            angle = 60f;
        }
    }
}
