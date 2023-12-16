using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GroupIntelect : MonoBehaviour
{
    [SerializeField]
    private float radius;

    public LayerMask mask;

    private Enemy _enemy;
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        StartCoroutine("CheckerRout");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator CheckerRout()
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
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, mask);
        if (rangeChecks.Length != 0)
        {
            foreach (var collider in rangeChecks)
            {
                if (collider.CompareTag("Enemy"))
                {
                    if (collider.name != "General5")
                    {
                        if (GetComponent<Enemy>().canSeePlayer)
                        {
                            if (!collider.GetComponent<Enemy>().canSeePlayer)
                            {
                                collider.GetComponent<Enemy>().Group(_enemy.dest);
                            }
                        }
                    }
                }
            }

        }
    }
}

