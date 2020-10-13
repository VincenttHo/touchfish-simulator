using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGun : MonoBehaviour
{

    private GameObject currentGameObject;
    public GameObject handGun;
    public GameObject machineGun;
    public GameObject shotGun;

    private void Start()
    {
        handGun.gameObject.SetActive(true);
        currentGameObject = handGun;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DoSwitch(handGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DoSwitch(machineGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DoSwitch(shotGun);
        }
    }

    void DoSwitch(GameObject gun)
    {
        gun.SetActive(true);
        currentGameObject.SetActive(false);
        currentGameObject = gun;
    }
}
