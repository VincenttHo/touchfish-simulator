using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyController : EnemyController
{

    protected override void Start()
    {
        base.Start();
    }

    protected new void Update()
    {
        rigi.velocity = transform.forward * speed;
    }
}
