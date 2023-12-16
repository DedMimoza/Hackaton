using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hinter : MonoBehaviour
{
    public LayerMask mask;
    [SerializeField, Range(0,10f)] public float radius;

    private Animator _animator;
    void Start()
    {
        StartCoroutine(CheckerRout());
        _animator = GetComponent<Animator>();
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
                    if (Input.GetKey(KeyCode.F))
                    {
                        _animator.SetTrigger("Hit");
                        collider.gameObject.GetComponent<Failture>().Die();
                    }
                }

                if (collider.CompareTag("Doks"))
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(collider.gameObject);
                        StartCoroutine(END());
                    }
                }
            }
        }
    }
    IEnumerator END()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(4);
    }
}
