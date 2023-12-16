using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failture : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Die()
    {
        StartCoroutine("DIE");
    }

    IEnumerator DIE()
    {
        if (name != "General5")
        {
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<GroupIntelect>().enabled = false;
            GetComponent<PodsvetHint>().enabled = false;
            GetComponent<IdleEnemy>().enabled = false;
            GetComponent<Enemy>().enabled = false;
        }
        Destroy(GetComponent<CapsuleCollider>());
        Destroy(GetComponent<PodsvetHint>().hint);

        _animator.applyRootMotion = true;
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("Die");
        _animator.SetBool("Dead", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        throw new NotImplementedException();
    }
}
