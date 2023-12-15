using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodsvetHint : MonoBehaviour
{
    
    private GameObject hint;
    public float radius;
    public LayerMask _mask;
    void Start()
    {
        hint = transform.GetChild(0).gameObject;
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
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, _mask);
        if (rangeChecks.Length != 0)
        {
            foreach (var collider in rangeChecks)
            {
                if (collider.CompareTag("Player"))
                {
                    hint.SetActive(true);
                }
                

            }
        }
        else
        {
            hint.SetActive(false);
        }
    }
}
