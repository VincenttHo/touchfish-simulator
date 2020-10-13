using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunController : GunController
{

    protected new void Update()
    {
        base.Update();
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

}
