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
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("Die");
    }

    private void OnCollisionEnter(Collision collision)
    {
        throw new NotImplementedException();
    }
}
