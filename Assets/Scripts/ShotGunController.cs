using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunController : MonoBehaviour
{

    public int bulletNum;
    public float bulletAngle;

    public GameObject bullet;
    public Transform shootPos;

    public float shootIntervalTime;
    private float shootTimer;

    protected void Start()
    {
        shootTimer = shootIntervalTime;
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (shootTimer >= shootIntervalTime)
        {
            InitBullet();
            shootTimer = 0;
        }
    }

    void InitBullet()
    {

        /*var newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        Quaternion rotateQuate = Quaternion.AngleAxis(0, transform.up);
        newBullet.transform.rotation = transform.rotation * rotateQuate;

        var newBullet1 = Instantiate(bullet);
        newBullet1.transform.position = transform.position;
        Quaternion rotateQuate1 = Quaternion.AngleAxis(15, transform.up);
        newBullet1.transform.rotation = transform.rotation * rotateQuate1;

        var newBullet2 = Instantiate(bullet);
        newBullet2.transform.position = transform.position;
        Quaternion rotateQuate2 = Quaternion.AngleAxis(30, transform.up);
        newBullet2.transform.rotation = transform.rotation * rotateQuate2;

        var newBullet3 = Instantiate(bullet);
        newBullet3.transform.position = transform.position;
        Quaternion rotateQuate3 = Quaternion.AngleAxis(-15, transform.up);
        newBullet3.transform.rotation = transform.rotation * rotateQuate3;

        var newBullet4 = Instantiate(bullet);
        newBullet4.transform.position = transform.position;
        Quaternion rotateQuate4 = Quaternion.AngleAxis(-30, transform.up);
        newBullet4.transform.rotation = transform.rotation * rotateQuate4;*/

        for(int n = 1; n <= (bulletNum - 1) / 2; n++)
        {
            InitBullet(n * bulletAngle);
        }
        for (int n = 1; n <= (bulletNum - 1) / 2; n++)
        {
            InitBullet(-n * bulletAngle);
        }
        InitBullet(0);
    }

    void InitBullet(float angle)
    {
        var newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        Quaternion rotateQuate = Quaternion.AngleAxis(angle, transform.up);
        newBullet.transform.rotation = transform.rotation * rotateQuate;
    }

}
