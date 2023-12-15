using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class StupidNepices : MonoBehaviour
{
    private Animator _anim;
    
    void Start()
    {
        _anim = GetComponent<Animator>();

        StartCoroutine("stupid");
    }



    IEnumerator stupid()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(5f);
            _anim.SetInteger("Chance", UnityEngine.Random.Range(0,100));
            yield return new WaitForSeconds(.5f);
            _anim.SetInteger("Chance", 0);
        }
        
    }
}
