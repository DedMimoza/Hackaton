using System.Collections;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    public Transform bodytrans;

    public NavMeshAgent _navMeshAgent;
    public bool canSeePlayer;
    
    public GameObject playerRef;

    public Animator Animator;
    
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [SerializeField, Range(0,10f)] public float radius;
    [SerializeField,Range(0, 360f)] public float angle;

    void Start()
    {
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
        Animator.SetFloat("Velocity", _navMeshAgent.velocity.magnitude);
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
                    _navMeshAgent.speed = 3.5f;   
                    canSeePlayer = true;
                    _navMeshAgent.destination = target.position;
                    transform.LookAt(target);
                    angle = 360f;
                    radius = 10f;
                }

                else
                {
                    canSeePlayer = false;
                    angle = 60f;
                    radius = 4f;
                }
            }
            else
            {
                canSeePlayer = false;
                angle = 60f;
                radius = 4f;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            angle = 60f;
            radius = 4f;
        }
    }
}
