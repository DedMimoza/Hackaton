using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dangeer : MonoBehaviour
{
    public List<Enemy> canse = new List<Enemy>();
    public bool isDanger;

    private void Update()
    {
        var c = 0;
        foreach (var enemy in canse)
        {
            if (enemy._navMeshAgent.velocity.magnitude>0)
            {
                c++;
            }
            
        }

        isDanger = c > 0;
    }

}
