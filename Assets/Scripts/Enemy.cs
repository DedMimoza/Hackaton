using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class Enemy : MonoBehaviour
{

    public Transform dest;
    public GameObject danger;

    public NavMeshAgent _navMeshAgent;
    public bool canSeePlayer;
    
    public GameObject playerRef;

    public Animator Animator;

    public IdleEnemy IdleEnemy;
    
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [SerializeField, Range(0,10f)] public float radius;
    [SerializeField,Range(0, 360f)] public float angle;


    private GameObject SoundMan;
    
    private Character comoponentOfMainHero;

    //Sound
    SoundActivator soundActivator;

    void Start()
    {
        dest = transform;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        comoponentOfMainHero = playerRef.GetComponent<Character>();
        StartCoroutine(FOVRoutine());

        soundActivator = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundActivator>();
        soundActivator.isPhone = true;



        SoundMan = GameObject.Find("SoundManager");
        SoundMan.GetComponent<Dangeer>().canse.Add(GetComponent<Enemy>());
        
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
                    dest = target;
                     danger.SetActive(true);
                    _navMeshAgent.speed = 3.5f;   
                    canSeePlayer = true;
                    _navMeshAgent.destination = target.position;
                    transform.LookAt(target);
                    angle = 360f;
                    radius = 10f;
                    IdleEnemy.start_pos = transform.position;

                    soundActivator.SwapMusic(SoundMan.GetComponent<Dangeer>().isDanger);
                }

                else
                {
                    danger.SetActive(false);
                    canSeePlayer = false;
                    angle = 60f;
                    radius = comoponentOfMainHero.speed < 3 ? 3f : 5f;

                    soundActivator.SwapMusic(SoundMan.GetComponent<Dangeer>().isDanger);
                }
            }
            else
            {
                danger.SetActive(false);
                canSeePlayer = false;
                angle = 60f;
                radius = comoponentOfMainHero.speed < 3 ? 3f : 5f;
            }
        }
        else if (canSeePlayer)
        {
            danger.SetActive(false);
            canSeePlayer = false;
            angle = 60f;
            radius = comoponentOfMainHero.speed < 3 ? 3f : 5f;
        }
    }

    public void Group(Transform target)
    {
        danger.SetActive(true);
        _navMeshAgent.speed = 3.5f;   
        canSeePlayer = true;
        _navMeshAgent.destination = dest.position+new Vector3(UnityEngine.Random.Range(0.2f, 0.5f), 0,
            UnityEngine.Random.Range(0.2f, 0.5f));
        transform.LookAt(target);
        angle = 360f;
        radius = 10f;
        IdleEnemy.start_pos = transform.position;

        soundActivator.SwapMusic(SoundMan.GetComponent<Dangeer>().isDanger);
    }
}
