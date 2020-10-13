using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunController : GunController
{

    protected new void Update()
    {
        base.Update();
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

}
