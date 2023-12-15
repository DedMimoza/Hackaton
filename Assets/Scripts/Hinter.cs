using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinter : MonoBehaviour
{
    public LayerMask mask;
    [SerializeField, Range(0,10f)] public float radius;
    void Start()
    {
        StartCoroutine(CheckerRout());
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
                    //activate button kill
                }

                if (collider.CompareTag("Doks"))
                {
                    //activate button grab
                }
            }
        }
    }
}
